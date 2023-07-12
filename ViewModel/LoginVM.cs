using Microsoft.EntityFrameworkCore;
using Plants.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Plants.ViewModel
{
    internal class LoginVM : BindableBase
    {
        private string _errorStr;
        private string _username;
        private string _password;
        private bool _isVisible = true;

        public string ErrorStr
        {
            get { return _errorStr; }
            set
            {
                _errorStr = value;
                RaisePropertyChanged(nameof(ErrorStr));
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                RaisePropertyChanged(nameof(IsVisible));
            }
        }

        public DelegateCommand LoginCommand { get; }

        public LoginVM()
        {
            LoginCommand = new DelegateCommand(() =>
            {
                User tmp = Context.GetInstance().Users.Include(u => u.UserRole).FirstOrDefault(x => x.UserName.Equals(this.Username) && x.Password.Equals(this.Password));
                if (tmp == null)
                {
                    ErrorStr = "Invalid data";
                    return;
                }
                if (tmp.UserRole != null) IsVisible = false;
            });
        }
    }
}
