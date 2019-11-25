using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Project_Imvi.Models
{
    public class ImageModel
    {
    }

    public class MainImage : INotifyPropertyChanged
    {
        private Uri imageUri;
        private BitmapImage imageBitmap;

        public Uri ImageUri
        {
            get
            {
                return imageUri;
            }

            set
            {
                if (imageUri != value)
                {
                    imageUri = value;
                    RaisePropertyChanged();
                }
            }
        }

        public BitmapImage ImageBitmap
        {
            get
            {
                return imageBitmap;
            }

            set
            {
                if (imageBitmap != value)
                {
                    imageBitmap = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string property = "")
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
