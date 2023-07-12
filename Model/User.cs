using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Model
{
    internal class User : BindableBase
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string userName;

		public string UserName
        {
			get { return userName; }
			set { userName = value; }
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private Role userRole;

		public Role UserRole
		{
			get { return userRole; }
			set { userRole = value; }
		}

        public User()
        {
            this.Id = 0;
			UserName = string.Empty;
			Password = string.Empty;
			UserRole = null;
        }

		public override string ToString() => $"{UserRole} - {UserName}";
        public override bool Equals(object? obj)
        {
			if (obj == null) return false;
			if (!(obj is User)) return false;
			User tmp = obj as User;
			if (tmp.UserName.Equals(UserName) && tmp.Password.Equals(Password)) return true;
			return false;
        }
    }
}
