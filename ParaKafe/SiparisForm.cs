using ParaKafe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParaKafe
{
    public partial class SiparisForm : Form
    {
        public event EventHandler<MasaTasindiEventArgs> MasaTasindi; //Masatasindievent args eventine delege tanımladık

        private readonly Siparis siparis;
        private readonly KafeVeri db;
        private readonly BindingList<SiparisDetay> blDetaylar;

        public SiparisForm(Siparis siparis, KafeVeri db)
        {
            this.siparis = siparis;
            this.db = db;
            blDetaylar = new BindingList<SiparisDetay>(siparis.SiparisDetaylar);
            blDetaylar.ListChanged += BlDetaylar_ListChanged; //eski sipariş üzerine yeni siparis ekleyince tutarı güncelleme için EVENT kullandık +=tab
            InitializeComponent();
            dgvSiparisDetaylar.AutoGenerateColumns = false;
            dgvSiparisDetaylar.DataSource = blDetaylar;
            UrunleriListele();
            MasaNoyuGuncelle();
            OdemeTutariniGuncelle();
        }

        private void BlDetaylar_ListChanged(object sender, ListChangedEventArgs e)
        {
            OdemeTutariniGuncelle();
        }

        private void OdemeTutariniGuncelle()
        {
            lblOdemeTutari.Text = siparis.ToplamTutarTL;
        }

        private void MasaNoyuGuncelle() //Masayı seçtiğimizde siparisForm ekranında hangi masanın olduğunu yazar
        {
            Text = $"Masa {siparis.MasaNo}(Açılış:{siparis.AcilisZamani})";
            lblMasaNo.Text = siparis.MasaNo.ToString("00"); //MASA DEĞİŞTİRMEK İÇİN
            int[] doluMasalar = db.AktifSiparisler.Select(x => x.MasaNo).ToArray();
            cboMasaNo.DataSource = Enumerable
                .Range(1, db.MasaAdeti)//1den MASA ADETİ KADAR OLAN MASALARI
                .Where(x=>!doluMasalar.Contains(x)) //Dolu masaları İÇERMEYEN
                .ToList(); //LERİ LİSTELEDİK
        }

        private void UrunleriListele()
        {
            cboUrun.DataSource = db.Urunler;
        }

        private void btnEkle_Click(object sender, EventArgs e) //Siparis ekleme butonu
        {
            SiparisDetay sd = new SiparisDetay();
            Urun urun = (Urun)cboUrun.SelectedItem;
            sd.UrunAd = urun.UrunAd;
            sd.BirimFiyat = urun.BirimFiyat;
            sd.Adet = (int)nudAdet.Value;
            blDetaylar.Add(sd); //mevcut siparisin detaylarina ekledik
        }

        private void btnAnaSayfayaDon_Click(object sender, EventArgs e)
        {
            Close(); //SiparisFormu kapatıp anaforma döner
        }

        private void btnSiparisIptal_Click(object sender, EventArgs e)
        {
            SiparisiKapat(SiparisDurum.Iptal, 0);
           
            //siparis.Durum = SiparisDurum.Iptal; //Siparis durumunu Iptal yaptik 
            //db.AktifSiparisler.Remove(siparis);//benzerlikler cok old. için metotlaştırdık 
            //db.GecmisSiparisler.Add(siparis);//Yorumlu kısımlar metotlaştırma öncesi yapılanlar****
            //Close();
        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            SiparisiKapat(SiparisDurum.Odendi, siparis.ToplamTutar());

            //siparis.Durum = SiparisDurum.Odendi; //Siparis durumunu Odendi yaptik
            //siparis.OdenecekTutar = siparis.ToplamTutar();//METOTLAŞTIRMA ÖNCESİ*****
            //db.AktifSiparisler.Remove(siparis);
            //db.GecmisSiparisler.Add(siparis);
            //Close();
        }

        private void SiparisiKapat(SiparisDurum durum, decimal odenenTutar) //METOTLAŞTIRILMIŞ HALİ***
        {
            siparis.KapanisZamani = DateTime.Now;
            siparis.Durum = durum;
            siparis.OdenecekTutar = odenenTutar;
            db.AktifSiparisler.Remove(siparis);
            db.GecmisSiparisler.Add(siparis);
            Close();


        }

        private void btnMasaTasi_Click(object sender, EventArgs e) //MASA TAŞIMA
        {
            if (cboMasaNo.SelectedIndex == -1) return; //seçili masa yoksa çık
            int eskiMasaNo = siparis.MasaNo;
            int hedefMasaNo = (int)cboMasaNo.SelectedItem; //hedef masa=> seçilen masaya eşitledik
            siparis.MasaNo = hedefMasaNo;// =>siparisleri hedef masaya taşıdık
            MasaNoyuGuncelle(); //=> masa noyu güncelledik
            if (MasaTasindi != null)
                MasaTasindi(this, new MasaTasindiEventArgs(eskiMasaNo, hedefMasaNo));

        }
    }
}
