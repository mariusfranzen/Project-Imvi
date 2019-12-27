using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Project_Imvi.VariousClasses
{
    class Functions
    {
        public static SolidColorBrush HexToBrush(string hex)
        {
            hex = hex.Replace("#", "");
            Console.WriteLine(hex);
            if (hex.Length == 6)
            {
                return new SolidColorBrush(Color.FromArgb(255,
                    byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            else if (hex.Length == 8)
            {
                return new SolidColorBrush(Color.FromArgb(255,
                    byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            else
            {
                return null;
            }
        }
    }
}
