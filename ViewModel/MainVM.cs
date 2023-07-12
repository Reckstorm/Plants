using Plants.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Plants.ViewModel
{
    internal class MainVM : BindableBase
    {
        readonly LoginVM _loginModel = new LoginVM();
        private User currentUser;
        public MainVM()
        {
            _loginModel.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);
            LoginCommand = new DelegateCommand(() =>
            {

            });
        }
        public DelegateCommand LoginCommand { get; }
        public LoginVM LoginModel => _loginModel;
    }
}
