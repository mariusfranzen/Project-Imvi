using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Imvi.Models
{
    class ImageModel
    {
    }

    public class MainImage : INotifyPropertyChanged
    {
        private Uri imageUri;

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

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
                    RaisePropertyChanged("ImageUri");
                }
            }
        }
    }
}
