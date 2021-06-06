using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Restorant_Server.Class;


namespace Restorant_Server
{
    public partial class Tanimlar : Form
    {
        public Tanimlar()
        {
            InitializeComponent();
        }
        bool durum;
        string id = "";
        string masaid = "";
      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //urun kaydı 
            try
            {
                if (textEdit1.Text != "" || textEdit2.Text != "" || spinEdit1.Value != 0 || comboBoxEdit1.Text != "")
                {
                    if (id != "")
                    {
                        //eger id bos degılse verıyı gunceller
                        double TOPLAM = Convert.ToDouble(spinEdit1.Text) * Convert.ToDouble(textEdit2.Text);
                        DataClass.DataClass.URUN_GUNCELLE(id, comboBoxEdit1.Text, textEdit1.Text, spinEdit1.Text, Convert.ToDouble(textEdit2.Text), TOPLAM, ref durum);
                        if (durum == true)
                        {
                            //durum true ıse urun gunllenır
                            gridControl1.DataSource = DataClass.DataClass.URUNLER_YUKLE();
                            MessageBox.Show("Ürün Güncellendi");
                            id = "";
                        }
                        else
                        {

                            MessageBox.Show("Hata:Ürün Güncellenemedi!!!");
                        }
                        simpleButton4.Enabled = true;
                    }
                    else
                    {
                        //id bos ıse yenı kayıt olusturulur
                        float toplamfiyat = Convert.ToSingle(spinEdit1.Value) * Convert.ToSingle(textEdit2.Text);
                        DataClass.DataClass.URUN_TANIMLAMA(comboBoxEdit1.Text, textEdit1.Text, spinEdit1.Text, Convert.ToDouble(textEdit2.Text), toplamfiyat, ref durum);
                        if (durum == true)
                        {
                            gridControl1.DataSource = DataClass.DataClass.URUNLER_YUKLE();
                            MessageBox.Show("Ürün Kaydı Yapıldı");
                        }
                        else
                        {

                            MessageBox.Show("Hata:Kayıt Yapılamadı!!!");
                        }

                    }
                    id = "";
                    textEdit1.Enabled = false;
                    textEdit2.Enabled = false;
                    comboBoxEdit1.Enabled = false;
                    spinEdit1.Enabled = false;
                    simpleButton3.Enabled = false;
                    simpleButton1.Enabled = false;
                    simpleButton4.Enabled = true;
                    simpleButton5.Enabled = false;
                    spinEdit1.Text = "";
                    textEdit1.Text = "";
                    textEdit2.Text = "";
                    comboBoxEdit1.Text = "";

                }
                else
                {
                    MessageBox.Show("Alanları dolurun");
                }
            }
            catch
            {
                return;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //urun sılme
            try
            {
                if (id != "")
                {
                    DataClass.DataClass.URUN_SIL(id, ref durum);
                    if (durum == true)
                    {
                        gridControl1.DataSource = DataClass.DataClass.URUNLER_YUKLE();
                        MessageBox.Show("Ürün Silindi");
                    }
                    else
                    {

                        MessageBox.Show("Hata:Silinemedi!!!");
                    }
                }
                else
                {
                    MessageBox.Show("İlk önce silinecek veriyi seçin");
                }
                id = "";
            }
            catch
            {
                return;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            id = "";
            textEdit1.Enabled = true;
            textEdit2.Enabled = true;
            comboBoxEdit1.Enabled = true;
            spinEdit1.Enabled = true;
            simpleButton3.Enabled = false;
            simpleButton4.Enabled = false;
            simpleButton1.Enabled = true;
            simpleButton5.Enabled = true;
        }

      

        private void Tanimlar_Load(object sender, EventArgs e)
        {
         //form acılısında uygulanacak sılemler
            gridView1.GroupPanelText = "Verileri guruplamak için kolonları sürükleyin";
            urun_getir();
            masa_getir();
        }
      
        void urun_getir()
        {
            try
            {
                //URUN GETIR GRIDE YUKLER
                gridControl1.DataSource = DataClass.DataClass.URUNLER_YUKLE();
                gridView1.Columns[0].Visible = false;
            }
            catch
            {
                return;
            }
        }
        void masa_getir()
        {
            try
            {
                //MASA GETIR GRIDE YUKLER
                gridControl2.DataSource = DataClass.DataClass.MASA_SELECT();
                gridView2.Columns[0].Visible = false;
            }
            catch
            {
                return;
            }
        }

     

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            simpleButton4.Enabled = true;
            simpleButton1.Enabled = false;
            simpleButton5.Enabled = false;
            simpleButton3.Enabled = true;
            textEdit1.Enabled = false;
            textEdit2.Enabled = false;
            comboBoxEdit1.Enabled = false;
            spinEdit1.Enabled = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
           
            try
            {
                //GRITTEKI HUCREDEN VERI ALMAK ICIN KULLANILIR
                textEdit1.Enabled = true;
                textEdit2.Enabled = true;
                comboBoxEdit1.Enabled = true;
                spinEdit1.Enabled = true;
                simpleButton3.Enabled = true;
                simpleButton1.Enabled = true;
                simpleButton4.Enabled = false;
                simpleButton5.Enabled = true;
               id = this.gridView1.GetFocusedRowCellDisplayText(this.gridView1.Columns[0]);
              comboBoxEdit1.Text = this.gridView1.GetFocusedRowCellDisplayText(this.gridView1.Columns[1]);
               textEdit1.Text = this.gridView1.GetFocusedRowCellDisplayText(this.gridView1.Columns[2]);
               spinEdit1.Text = this.gridView1.GetFocusedRowCellDisplayText(this.gridView1.Columns[3]);
               textEdit2.Text = this.gridView1.GetFocusedRowCellDisplayText(this.gridView1.Columns[4]);
               
            }
            catch
            {
                return;
            }
        }

   //ALT TARFTA BULUNAN KOD YAPILARI DATABASE MASA ISIMLERINI YAZMAK,GUNCELLEMEK VE SILMEK ICIN KULLANILIR
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit3.Text != "")
                {
                    if (masaid != "")
                    {//UPDATE ISLEMI
                        DataClass.DataClass.MASA_UPDATE(textEdit3.Text,masaid, ref durum);
                        if (durum == true)
                        {
                            MessageBox.Show("Güncelleme yapıldı");
                            masa_getir();
                            textEdit3.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme yapılamadı");
                        }

                    }
                    else
                    {
                        if (gridView2.RowCount != 20)
                        {
                            DataClass.DataClass.MASA_INSERT(textEdit3.Text, ref durum);
                            if (durum == true)
                            {//INSERT ISLEMI
                                MessageBox.Show("Kayıt yapıldı");
                                masa_getir();
                                textEdit3.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Kayıt yapılamadı");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Maksimum masa sayısına ulaşıldı");
                        }
                    }
                    masaid = "";
                }
                else
                {
                    MessageBox.Show("Masa adını yazın");
                }
            }
            catch
            {
                return;
            }

        }

  

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

            panel2.Visible = false;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {//GRITTEN HUCRELERDEN VERI ALMAK ICIN KULLANILAN KOD YAPISI
               
                masaid = this.gridView2.GetFocusedRowCellDisplayText(this.gridView2.Columns[0]);
                textEdit3.Text = this.gridView2.GetFocusedRowCellDisplayText(this.gridView2.Columns[1]);
            }
            catch
            {
                return;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (masaid != "")
                {//DELETE ISLEMI
                    DataClass.DataClass.MASA_DELETE(masaid, ref durum);
                    if (durum == true)
                    {
                        MessageBox.Show("Silindi");
                        masa_getir();
                    }
                    else
                    {
                        MessageBox.Show("Silinemedi");
                    }
                }
                else
                {
                    MessageBox.Show("Veri seçin");
                }
            }
            catch
            {
                return;
            }
        }
    }
}
