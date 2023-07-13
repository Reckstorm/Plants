using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Plants.Converters;
using Plants.Model;
using Plants.View;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Plants.ViewModel
{
    internal class MainVM : BindableBase
    {
        readonly PlantVM _model = new PlantVM();
        private Plant selectedPlant;
        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                RaisePropertyChanged(nameof(currentUser));
            }
        }
        public MainVM()
        {
            LoadCurrentUser();
            _model.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);
            AddCommand = new DelegateCommand(() =>
            {
                _model.AddCommand(new Plant());
                ViewDetailsCommand.Execute();
            });
            RemoveCommand = new DelegateCommand<Plant>(plant =>
            {
                _model.RemoveCommand(plant);
                Application.Current.Windows.OfType<PlantDetailedView>().First().Close();
            });
            SaveCommand = new DelegateCommand<Plant>(plant =>
            {
                if (plant == null) return;
                if (plant.CommonName.Equals(string.Empty) ||
                    plant.SciName.Equals(string.Empty) ||
                    plant.Description.Equals(string.Empty) ||
                    plant.Region.Equals(string.Empty) ||
                    plant.Pros.Equals(string.Empty) ||
                    plant.Cons.Equals(string.Empty) ||
                    plant.ImgSource.Equals(string.Empty)
                ) return;
                else
                {
                    _model.SaveCommad(plant);
                    Application.Current.Windows.OfType<PlantDetailedView>().First().Close();
                }
            });
            ViewDetailsCommand = new DelegateCommand(() =>
            {
                PlantDetailedView view = new PlantDetailedView();
                view.DataContext = this;
                view.Show();
            });
            PickImageCommand = new DelegateCommand(() =>
            {
                _model.PickImageCommand();
            });
            SearchCommand = new DelegateCommand<TextBox>(tb =>
            {
                if (tb == null) return;
                _model.SearchCommad(tb);
            });
        }

        private void LoadCurrentUser()
        {
            if (Thread.CurrentPrincipal == null) return;
            using (Context c = new Context())
            {
                CurrentUser = c.Users.Include(u => u.UserRole).First(x => x.UserName.Equals(Thread.CurrentPrincipal.Identity.Name));
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand<Plant> RemoveCommand { get; }
        public DelegateCommand<Plant> SaveCommand { get; }
        public DelegateCommand ViewDetailsCommand { get; }
        public DelegateCommand PickImageCommand { get; }
        public DelegateCommand<TextBox> SearchCommand { get; }
        public ReadOnlyObservableCollection<Plant> Plants => _model.PublicPlants;

        public Plant SelectedPlant
        {
            get { return _model.SelectedPlant; }
            set { _model.SelectedPlant = value; }
        }
    }
}
