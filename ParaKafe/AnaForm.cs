using Newtonsoft.Json;
using ParaKafe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParaKafe
{
    public partial class AnaForm : Form
    {
        KafeVeri db = new KafeVeri();
        //deneme
        public AnaForm()
        {
            //OrnekUrunleriYukle();
            VerileriOku();
            InitializeComponent();
            MasalariOlustur();
        }

        private void OrnekUrunleriYukle() //Menuye önceden deneme amaçlı örnek ürün yükledik=> ürün ekle formundan sonra buraya gerek kalmadı
        {
            db.Urunler.Add(new Urun() { UrunAd = "Ayran", BirimFiyat = 4.50m });
            db.Urunler.Add(new Urun() { UrunAd = "Kola", BirimFiyat = 5.50m });
        }

        private void MasalariOlustur()
        {
            for (int i = 1; i <= db.MasaAdeti; i++)
            {
                ListViewItem lvi = new ListViewItem($"Masa {i}"); //Masa 1
                lvi.Tag = i; //Tag=>i=1 dedik mesela*
                lvi.ImageKey = db.AktifSiparisler.Any(x=>x.MasaNo==i)?"dolu2":"bos2"; //eğer aktif siparslerde hiç oturan varsa dolu değilse bos
                lvwMasalar.Items.Add(lvi);
            }
        }

        private void lvwMasalar_DoubleClick(object sender, EventArgs e) //çift tık yaptıgımızda masa nosu çıkartıyor.
        {
            ListViewItem lvi = lvwMasalar.SelectedItems[0];
            int no = (int)lvi.Tag;

            Siparis siparis = db.AktifSiparisler.FirstOrDefault(x => x.MasaNo == no); //FirstOrDefault=>masa nosu..olan siparisi getir dedik.

            if (siparis == null)  //eğer siparis getirilen masa boşsa (hiç siparis önceden alınmamıssa) aktif siparislere ekle ve resmi dolu resim yap.
            {
                siparis = new Siparis() { MasaNo = no };
                db.AktifSiparisler.Add(siparis);
                lvi.ImageKey = "dolu2";
            }

            SiparisForm sf = new SiparisForm(siparis, db); //SiparisForm formunu AnaForma bağladık.
            sf.MasaTasindi += Sf_MasaTasindi;
            sf.ShowDialog();// ve ekranda görünmesini sağladık.

            if (siparis.Durum != SiparisDurum.Aktif) //Eğer müşteri ödeme yaptıkysa(MASA AKTIF DEGILSE) masa tekrardan boş olucak
            {
                lvi.ImageKey = "bos2";
            }
        }

        private void Sf_MasaTasindi(object sender, MasaTasindiEventArgs e)
        {
            foreach (ListViewItem lvi in lvwMasalar.Items)
            {
                if ((int)lvi.Tag == e.EskiMasaNo) lvi.ImageKey = "bos2";
                if ((int)lvi.Tag == e.YeniMasaNo) lvi.ImageKey = "dolu2";

            }
        }

        private void tsmiGecmisSiparisler_Click(object sender, EventArgs e)
        {
            new GecmisSiparislerForm(db).ShowDialog();
        }

        private void tsmiUrunler_Click(object sender, EventArgs e)
        {
            new UrunlerForm(db).ShowDialog();
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            VerileriKaydet();
        }

        private void VerileriKaydet()
        {
            string json = JsonConvert.SerializeObject(db);
            File.WriteAllText("veri.json", json);
        }
        private void VerileriOku()
        {
            try
            {
                string json = File.ReadAllText("veri.Json");
                db = JsonConvert.DeserializeObject<KafeVeri>(json);
            }
            catch (Exception)
            {
                db = new KafeVeri();
                OrnekUrunleriYukle();
            }
        }
        
    }
}
