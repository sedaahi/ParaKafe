using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaKafe
{
   public class MasaTasindiEventArgs:EventArgs
    {
        public MasaTasindiEventArgs(int eskiMasaNo, int yeniMasaNo)
        {
            EskiMasaNo = eskiMasaNo;
            YeniMasaNo = yeniMasaNo;
        }

        public int EskiMasaNo { get; }
        public int YeniMasaNo { get; }
    }
}
