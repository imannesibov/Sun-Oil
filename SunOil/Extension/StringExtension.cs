using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunOil.Extension
{
    static class StringExtension
    {
        public static bool isString(this string main, string str)
        { 

            try
            {
                if (Convert.ToDouble(str) >= 0|| Convert.ToDouble(str) < 999)
                {
                    return true;
                }
                
            }
            catch (System.FormatException)
            {
                System.Windows.Forms.MessageBox.Show("you can Only use Numbers");
            }
            return false;
        }
    }
}
