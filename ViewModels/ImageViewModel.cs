using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Imvi.Models;

namespace Project_Imvi.ViewModels
{
    class ImageViewModel
    {
        public ImageViewModel()
        {

        }
        public MainImage Image
        {
            get;
            set;
        }

        private void LoadImage()
        {
            if (true /*TODO: program not opened with image*/)
            {
                Image.ImageUri = null;
            }
            else
            {
                //TODO: Load image selected by user
            }
        }
    }
}
