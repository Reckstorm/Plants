using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Plants.Model;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Plants.ViewModel
{
    internal class PlantVM : BindableBase
    {
        private List<Plant> _sourcePlants = new List<Plant>();
        private readonly ObservableCollection<Plant> _plants = new ObservableCollection<Plant>();
        public readonly ReadOnlyObservableCollection<Plant> PublicPlants;
        private Plant selectedPlant;

        public Plant SelectedPlant
        {
            get { return selectedPlant; }
            set
            {
                selectedPlant = value;
                RaisePropertyChanged(nameof(SelectedPlant));
            }
        }

        public PlantVM()
        {
            using (Context c = new Context())
            {
                foreach (Plant plant in c.Plants)
                {
                    _sourcePlants.Add(plant);
                }
                _plants = new ObservableCollection<Plant>(_sourcePlants);
                PublicPlants = new ReadOnlyObservableCollection<Plant>(_plants);
            }
        }

        public void PickImageCommand()
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}images";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string name = $@"{path}\{new Random().Next(1999999999)}{Path.GetExtension(openFileDialog.FileName)}";
                File.Copy(openFileDialog.FileName, name);
                SelectedPlant.ImgSource = name;
            }
        }

        public void SearchCommad(TextBox textBox)
        {
            string temp = textBox.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                foreach(Plant plant in _sourcePlants)
                {
                    if (!(plant.CommonName.ToLower().Contains(temp) ||
                          plant.SciName.ToLower().Contains(temp) ||
                          plant.Description.ToLower().Contains(temp) ||
                          plant.Pros.ToLower().Contains(temp) ||
                          plant.Cons.ToLower().Contains(temp)) &&
                          _plants.Any(x => x.Id.Equals(plant.Id)))
                    {
                        _plants.Remove(plant);
                    }
                    else if((plant.CommonName.ToLower().Contains(temp) ||
                          plant.SciName.ToLower().Contains(temp) ||
                          plant.Description.ToLower().Contains(temp) ||
                          plant.Pros.ToLower().Contains(temp) ||
                          plant.Cons.ToLower().Contains(temp)) &&
                          !_plants.Any(x => x.Id.Equals(plant.Id)))
                    {
                        _plants.Add(plant);
                    }
                }
            }
            else if (_plants.Count != _sourcePlants.Count() || !_plants[_plants.Count - 1].Id.Equals(_sourcePlants.LastOrDefault().Id))
            {
                _plants.Clear();
                foreach (Plant plant in _sourcePlants)
                {
                    _plants.Add(plant);
                }
            }
        }

        public void AddCommand(Plant plant)
        {
            _sourcePlants.Add(plant);
            _plants.Add(plant);
            SelectedPlant = plant;
        }

        public void RemoveCommand(Plant plant)
        {
            _sourcePlants.Add(plant);
            _plants.Remove(plant);
            Remove(plant);
        }

        public void SaveCommad(Plant plant)
        {
            if (plant.Id.Equals(0)) Add(plant);
            else Update(plant);
        }

        public void Add(Plant plant)
        {
            using (Context c = new Context())
            {
                c.Plants.Add(plant);
                c.SaveChanges();
            }
        }

        public void Update(Plant plant)
        {
            using (Context c = new Context())
            {
                c.Plants.Update(plant);
                c.SaveChanges();
            }
        }

        public void Remove(Plant plant)
        {
            using (Context c = new Context())
            {
                c.Plants.Remove(plant);
                c.SaveChanges();
            }
        }
    }
}
