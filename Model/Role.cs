using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Model
{
    internal class Role : BindableBase
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

        public Role()
        {
			id = 0;
			Name = string.Empty;
        }

        public override string ToString() => Name;
    }
}
