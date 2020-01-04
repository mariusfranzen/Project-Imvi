using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Project_Imvi.ViewModels;

namespace Project_Imvi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                MainWindow Window;
                if (e.Args.Length == 1)
                {
                    Window = new MainWindow(e.Args[0]);
                }
                else
                {
                    Window = new MainWindow();
                }
                Window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
