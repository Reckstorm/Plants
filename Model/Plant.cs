using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Model
{
    internal class Plant : BindableBase
    {
		private int id;

		public int Id
		{
			get { return id; }
			set 
			{ 
				id = value; 
				RaisePropertyChanged(nameof(Id));
			}
		}

		private string commonName;

		public string CommonName
		{
			get { return commonName; }
			set 
			{ 
				commonName = value; 
				RaisePropertyChanged(nameof(CommonName));
			}
		}

		private string sciName;

		public string SciName
        {
			get { return sciName; }
			set 
			{ 
				sciName = value; 
				RaisePropertyChanged(nameof(SciName));
			}
		}

		private string description;

		public string Description
        {
			get { return description; }
			set 
			{ 
				description = value; 
				RaisePropertyChanged(nameof(Description));
			}
		}

		private string pros;

		public string Pros
		{
			get { return pros; }
			set 
			{ 
				pros = value; 
				RaisePropertyChanged(nameof(Pros));
			}
		}

		private string cons;

		public string Cons
		{
			get { return cons; }
			set 
			{ 
				cons = value; 
				RaisePropertyChanged(nameof(Cons));
			}
		}

		private string region;

		public string Region
		{
			get { return region; }
			set 
			{ 
				region = value; 
				RaisePropertyChanged(nameof(Region));
			}
		}

        public Plant()
        {
			id = 0;
        }

		public override string ToString() => $"{Id} : {CommonName}";
    }
}
