using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWPragueParkingV1
{
    internal class InfoArray
    { 
        public static string[] ArrayParking = new string[101]; // 101 parking spots  
        public static void CreateParking()
        {
            ArrayParking[0] = "$"; // parking space $ used as a temp for moving vehicles if rest of parking is full                                 
            for (int row = 1; row < ArrayParking.Length; row++)
            {
                ArrayParking[row] = "0";
            }
        }
    }
}