using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Project_Imvi.VariousClasses;

namespace Project_Imvi.Models
{
    public sealed class CoreModel : INotifyPropertyChanged
    {

        #region Singleton code
        private static CoreModel instance = null;
        private static readonly object padlock = new object();

        CoreModel()
        {

        }

        public static CoreModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CoreModel();
                    }
                    return instance;
                }
            }
        }
        #endregion

        private SolidColorBrush backgroundColorHex;

        public SolidColorBrush BackgroundColorHex
        {
            get
            {
                try
                {
                    if (backgroundColorHex == null)
                    {
                        backgroundColorHex = Functions.HexToBrush("#ffffff");
                    }
                    return backgroundColorHex;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return backgroundColorHex;
                }
            }

            set
            {
                try
                {
                    if (backgroundColorHex != value)
                    {
                        backgroundColorHex = value;
                        RaisePropertyChanged();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        //INPC members. The PropertyChangedEventHandler handles the event raised when a property changes
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
