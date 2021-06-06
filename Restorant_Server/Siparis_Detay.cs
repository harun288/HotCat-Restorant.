using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restorant_Server
{
    public partial class Siparis_Detay : Form
    {
        public string MASANO = "";
        bool DURUM;
        string siparis_id = "";
        decimal toplam = 0;
        public Siparis_Detay()
        {
            InitializeComponent();
        }
        Masalar m = new Masalar();
        void yukle()
        {
            try
            {
                //listeye acık olan siparisleri listeler
                gridControl1.DataSource = DataClass.DataClass.SIPARIS_DETAY(MASANO, "1");
                gridView1.Columns[0].Visible = false; gridView1.Columns[1].Visible = false;
                DataClass.DataClass.SIPARIS_FIYATI(label3.Text,MASANO,ref toplam);
                //burada acıkoalan siparislerin toplam fiyatları gelir
                label5.Text = toplam.ToString()+" "+"TL";
            }
            catch(Exception c)
            {
                return;
            }
        }
        private void Siparis_Detay_Load(object sender, EventArgs e)
        {
            //form ilk çalıştıgında çalışan kod
            yukle();
        }

      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //hesapları kaptmak ıcın kullanılır
                if (gridView1.RowCount != 0)
                {
                    //hesabı kapatır
                    DataClass.DataClass.MASA_HESAPKAPAT(MASANO, ref DURUM);
                    if (DURUM == true)
                    {
                        //sıparısı kapatır
                        DataClass.DataClass.MASA_SIPARISKAPAT(MASANO, ref DURUM);
                        if (DURUM == true)
                        {
                            m.MASADURUMLARI();
                            MessageBox.Show("Sipariş kapatıldı");

                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kapatılacak hesap yok");
                }
            }
            catch
            {
                return;
            }
        }

        private void seçileniİptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //tek siparis urunu siler
                DataClass.DataClass.URUN_IPTALI(siparis_id, ref DURUM);
                if (DURUM == true)
                { //eger durum true ıse sıparıs sılınır ve yukler
                    yukle();
                    MessageBox.Show("Sipariş silindi");
                }
                else
                {
                    MessageBox.Show("Sipariş silinemedi");
                }
            }
            catch
            {
                return;
            }
        }

        private void tümSiparişiİptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //tum siparisi iptal etmek için 
                DataClass.DataClass.TUM_SIPARIS_IPTAL(MASANO, label3.Text, ref DURUM);
                if (DURUM == true)
                {
                    yukle();
                    MessageBox.Show("Tüm sipariş iptal edildi");
                }
                else
                {
                    MessageBox.Show("Sipariş iptal edilemedi");
                }
            }
            catch
            {
                return;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //secilen urunun idsini alır
                siparis_id = this.gridView1.GetFocusedRowCellDisplayText(this.gridView1.Columns[0]);
            }
            catch
            {
                return;
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
