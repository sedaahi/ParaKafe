
namespace ParaKafe
{
    partial class AnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.lvwMasalar = new System.Windows.Forms.ListView();
            this.imlMasalar = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiUrunler = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGecmisSiparisler = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwMasalar
            // 
            this.lvwMasalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMasalar.HideSelection = false;
            this.lvwMasalar.LargeImageList = this.imlMasalar;
            this.lvwMasalar.Location = new System.Drawing.Point(0, 24);
            this.lvwMasalar.Name = "lvwMasalar";
            this.lvwMasalar.Size = new System.Drawing.Size(561, 420);
            this.lvwMasalar.TabIndex = 1;
            this.lvwMasalar.UseCompatibleStateImageBehavior = false;
            this.lvwMasalar.DoubleClick += new System.EventHandler(this.lvwMasalar_DoubleClick);
            // 
            // imlMasalar
            // 
            this.imlMasalar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMasalar.ImageStream")));
            this.imlMasalar.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMasalar.Images.SetKeyName(0, "bos2");
            this.imlMasalar.Images.SetKeyName(1, "dolu2");
            this.imlMasalar.Images.SetKeyName(2, "bos");
            this.imlMasalar.Images.SetKeyName(3, "dolu");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUrunler,
            this.tsmiGecmisSiparisler});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(561, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiUrunler
            // 
            this.tsmiUrunler.Name = "tsmiUrunler";
            this.tsmiUrunler.Size = new System.Drawing.Size(58, 20);
            this.tsmiUrunler.Text = "Ürünler";
            this.tsmiUrunler.Click += new System.EventHandler(this.tsmiUrunler_Click);
            // 
            // tsmiGecmisSiparisler
            // 
            this.tsmiGecmisSiparisler.Name = "tsmiGecmisSiparisler";
            this.tsmiGecmisSiparisler.Size = new System.Drawing.Size(108, 20);
            this.tsmiGecmisSiparisler.Text = "Geçmiş Siparişler";
            this.tsmiGecmisSiparisler.Click += new System.EventHandler(this.tsmiGecmisSiparisler_Click);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 444);
            this.Controls.Add(this.lvwMasalar);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AnaForm";
            this.Text = "Para Kafe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvwMasalar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiUrunler;
        private System.Windows.Forms.ToolStripMenuItem tsmiGecmisSiparisler;
        private System.Windows.Forms.ImageList imlMasalar;
    }
}