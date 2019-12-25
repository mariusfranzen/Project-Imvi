using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Project_Imvi.ViewModels;
using Project_Imvi.Models;

namespace Project_Imvi.Views
{
    /// <summary>
    /// Interaction logic for SettingsWIndow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private SettingsViewModel viewModel = new SettingsViewModel();
        public SettingsWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void BackgroundColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string HexCode = BackgroundColorPicker.SelectedColor.ToString();
            viewModel.SetBackgroundColor(HexCode);

        }
    }
}
