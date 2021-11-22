using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaKafe.Data
{
    public class Siparis
    {
        public int MasaNo { get; set; }
        public SiparisDurum Durum { get; set; }
        public decimal OdenecekTutar { get; set; }
        public DateTime? AcilisZamani { get; set; } = DateTime.Now; //zaman vermezsek otomatikmen o anki zamanı söyler
        public DateTime? KapanisZamani { get; set; }
        public List<SiparisDetay> SiparisDetaylar { get; set; } = new List<SiparisDetay>();
        public  string ToplamTutarTL { get { return $"{ToplamTutar():n2}₺"; } }
        public decimal ToplamTutar()
        {
            return SiparisDetaylar.Sum(x=>x.Tutar());
        }
    }
}
