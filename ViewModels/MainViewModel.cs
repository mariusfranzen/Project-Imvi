using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Project_Imvi.Models;
using Project_Imvi.ViewModels;
using Project_Imvi.Views;

namespace Project_Imvi.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        //ICommands that utilizes ICommands.cs to respond to commands from the view
        #region ICommands
        public ICommand OpenCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand OpenSettingsCommand { get; set; }

        public MainViewModel()
        {
            this.OpenCommand = new ICommands(ExecuteOpenCommand, CanExecuteOpenCommand);
            this.ExitCommand = new ICommands(ExecuteExitCommand, CanExecuteExitCommand);
            this.OpenSettingsCommand = new ICommands(ExecuteOpenSettingsCommand, CanExecuteOpenSettingsCommand);
        }

        public bool CanExecuteOpenCommand(object parameter)
        {
            return true; //TODO: Can execute open command?
        }

        public void ExecuteOpenCommand(object parameter)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                DefaultExt = "*.*",
                FilterIndex = 5,
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*"
            };

            Nullable<bool> result = openDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                Uri imageUri = new Uri(openDialog.FileName);
                LoadImage(imageUri);
            }
        }

        public bool CanExecuteExitCommand(object parameter)
        {
            return true; //TODO: Can execute exit command?
        }

        public void ExecuteExitCommand(object parameter)
        {

        }

        public bool CanExecuteOpenSettingsCommand(object parameter)
        {
            return true; //TODO: Can execute settings command?
        }

        public void ExecuteOpenSettingsCommand(object parameter)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        #endregion

        private MainImage _Image;
        public MainImage Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (_Image != value)
                {
                    _Image = value;
                    RaisePropertyChanged();
                }
            }
        }

        private void LoadImage(Uri imageUri)
        {
            MainImage image = new MainImage();

            if (false /*Loaded through "open with"*/)
            {
                //TODO: code for "open with"
            }
            else
            {
                image.ImageUri = imageUri;
                image.ImageBitmap = new BitmapImage(imageUri);
            }
            Image = image;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
