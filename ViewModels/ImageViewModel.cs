using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using Project_Imvi.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project_Imvi.ViewModels
{
    public class ImageViewModel : INotifyPropertyChanged
    {
        //ICommands that utilizes ICommands.cs to respond to commands from the view
        #region ICommands
        public ICommand OpenCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public ImageViewModel()
        {
            this.OpenCommand = new ICommands(ExecuteOpenCommand, CanExecuteOpenCommand);
            this.ExitCommand = new ICommands(ExecuteExitCommand, CanExecuteExitCommand);
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
                _Image = value;
                RaisePropertyChanged();
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
