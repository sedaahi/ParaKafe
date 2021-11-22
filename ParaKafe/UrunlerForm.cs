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
    public partial class UrunlerForm : Form
    {
        private readonly KafeVeri db;
        private readonly BindingList<Urun> blUrunler;
        public UrunlerForm(KafeVeri db)
        {
            this.db = db;
            blUrunler = new BindingList<Urun>(db.Urunler);
            InitializeComponent();
            dgvUrunler.DataSource = blUrunler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string urunAd = txtUrunAd.Text.Trim();
            if (urunAd=="")
            {
                MessageBox.Show("Ürün Adını Girmediniz!");
                return;
            }
            blUrunler.Add(new Urun()
            {
                UrunAd = urunAd,
                BirimFiyat = nudBirimFiyat.Value
            });
            txtUrunAd.Clear();
            nudBirimFiyat.Value = 0;
        }
    }
}
