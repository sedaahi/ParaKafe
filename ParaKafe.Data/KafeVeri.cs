using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaKafe.Data
{
    public class KafeVeri
    {
        public int MasaAdeti { get; set; } = 20; //biz 20 adet dedik ama istenirse sonradan da değiştirilebilir.
        public List<Urun> Urunler { get; set; } = new List<Urun>();  //Default olarak şimdiden tanımladık kolaylık olması için
        public List<Siparis> AktifSiparisler { get; set; } = new List<Siparis>();
        public List<Siparis> GecmisSiparisler { get; set; } = new List<Siparis>();
    }
}
