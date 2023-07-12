using Plants.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Plants
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, EventArgs e)
        {
            var Login = new Login();
            Login.Show();
            Login.IsVisibleChanged += (s, e) =>
            {
                if (Login.IsVisible == false && Login.IsLoaded)
                {
                    var MainWindow = new MainWindow();
                    MainWindow.Show();
                    Login.Close();
                }
            };
        }
    }
}
