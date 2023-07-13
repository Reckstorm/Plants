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
                    _plants.Add(plant);
                }
                PublicPlants = new ReadOnlyObservableCollection<Plant>(_plants);
            }
        }

        public void PickImageCommand()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string name = $@"{path}images\{openFileDialog.SafeFileName}";
                File.Copy(openFileDialog.FileName, name);
                SelectedPlant.ImgSource = name;
            }
        }

        public void SearchCommad(TextBox textBox)
        {
            string temp = textBox.Text.ToLower();
            using (Context c = new Context())
            {
                _plants.Clear();
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    foreach (Plant plant in c.Plants)
                    {
                        if (plant.CommonName.ToLower().Contains(temp) ||
                            plant.SciName.ToLower().Contains(temp) ||
                            plant.Description.ToLower().Contains(temp) ||
                            plant.Pros.ToLower().Contains(temp) ||
                            plant.Cons.ToLower().Contains(temp))
                        {
                            _plants.Add(plant);
                        }
                    }
                }
                else if(_plants.Count != c.Plants.Count() || !_plants[_plants.Count-1].Id.Equals(c.Plants.LastOrDefault().Id))
                {
                    foreach (Plant plant in c.Plants)
                    {
                        _plants.Add(plant);
                    }
                }
            }
        }

        public void AddCommand(Plant plant)
        {
            _plants.Add(plant);
            SelectedPlant = plant;
        }

        public void RemoveCommand(Plant plant)
        {
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
