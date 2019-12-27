using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Project_Imvi.Models;
using Project_Imvi.VariousClasses;

namespace Project_Imvi.ViewModels
{
    class SettingsViewModel : INotifyPropertyChanged
    {

        public SettingsViewModel()
        {
        }

        public void SetBackgroundColor(string hex)
        {
            CoreModel.Instance.BackgroundColorHex = Functions.HexToBrush(hex);
        }

        //INPC members. The PropertyChangedEventHandler handles the event raised when a property changes
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
