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
		private string commonName;
		private string sciName;
		private string description;
		private string pros;
		private string cons;
		private string region;
		private string imgSource;

		public int Id
		{
			get { return id; }
			set 
			{ 
				id = value; 
				RaisePropertyChanged(nameof(Id));
			}
		}
		public string CommonName
		{
			get { return commonName; }
			set 
			{ 
				commonName = value; 
				RaisePropertyChanged(nameof(CommonName));
			}
		}
		public string SciName
        {
			get { return sciName; }
			set 
			{ 
				sciName = value; 
				RaisePropertyChanged(nameof(SciName));
			}
		}
		public string Description
        {
			get { return description; }
			set 
			{ 
				description = value; 
				RaisePropertyChanged(nameof(Description));
			}
		}
		public string Pros
		{
			get { return pros; }
			set 
			{ 
				pros = value; 
				RaisePropertyChanged(nameof(Pros));
			}
		}
		public string Cons
		{
			get { return cons; }
			set 
			{ 
				cons = value; 
				RaisePropertyChanged(nameof(Cons));
			}
		}
		public string Region
		{
			get { return region; }
			set 
			{ 
				region = value; 
				RaisePropertyChanged(nameof(Region));
			}
		}
		public string ImgSource
        {
			get { return imgSource; }
			set 
			{ 
				imgSource = value;
                RaisePropertyChanged(nameof(ImgSource));
            }
		}
		public Plant()
        {
			id = 0;
			CommonName = string.Empty; 
			SciName = string.Empty;
			Description = string.Empty;
			Pros = string.Empty;
			Cons = string.Empty;
            Region = string.Empty;
			ImgSource = string.Empty;
        }

		public override string ToString() => $"{Id} : {CommonName}";
    }
}
