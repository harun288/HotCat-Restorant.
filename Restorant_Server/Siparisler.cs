using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restorant_Server
{
    public partial class Siparisler : Form
    {
        public Siparisler()
        {
            InitializeComponent();
        }
        BindingSource bs;
        BindingSource bs2;
        BindingSource bs3;
        public string MASANO = "";
        public string MASAADI = "";
        double FIYAT = 0;
        bool durum;
        decimal toplam = 0;
        decimal toplamfiyat = 0;
        string ID = "";
        public void GURUP_YUKLE()
        {
            try
            {
                bs = new BindingSource();
                bs.DataSource = DataClass.DataClass.URUN_GURUP();
                comboBox1.DisplayMember = "GURUPADI";
                comboBox1.DataSource = bs;
            }
            catch
            {
                return;
            }

        }
        public void URUN_YUKLE()
        {
            try
            {

                //urunlerı comboboxa yukler
                bs2 = new BindingSource();
                bs2.DataSource = DataClass.DataClass.URUNLER(comboBox1.Text);
                comboBox2.DisplayMember = "URUNADI";
                comboBox2.ValueMember = "ID";
                comboBox2.DataSource = bs2;
            }
            catch
            {
                return;
            }

        }
        public void SIPARISLER_YUKLE()
        {
            try
            {
                //acık sıparıslerı gride yukler
                bs3 = new BindingSource();
                bs3.DataSource = DataClass.DataClass.ACIK_SIPARIS_GETIR(comboBox3.SelectedValue.ToString(), "1");
              
               dataGrid1.DataSource = bs3;
            }
            catch
            {
                return;
            }

        }
     
        private void Siparisler_Load(object sender, EventArgs e)
        {
            //ilk açılışta çalışan kodlar
            comboBox3.DataSource = DataClass.DataClass.MASALAR();
            comboBox3.DisplayMember = "MASAADI";
            comboBox3.ValueMember = "MASANO";
           
            GURUP_YUKLE();
            TOPLAM_FIYAT();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //secilen urun miktarı veurun fıyatının carpımı net sonucu verır
                if (numericUpDown1.Value != 0)
                {
                    toplam = Convert.ToDecimal(FIYAT) * Convert.ToDecimal(numericUpDown1.Value);
                    label8.Text = toplam.ToString() + "TL";
                }
                if (numericUpDown1.Value == 0)
                {
                    label8.Text = "0" + "TL";
                }
            }
            catch
            {
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grup secılınce guruba aıt urunler gelır
            URUN_YUKLE();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //secılen urune aıt fıyat bılgısı getırır
                DataClass.DataClass.URUN_FIYAT(comboBox2.SelectedValue.ToString(), ref FIYAT);
                label8.Text = FIYAT.ToString() + "TL";
            }
            catch
            {
                return;
            }
        }
        void TOPLAM_FIYAT()
        {
            try
            {
                //sıparıs toplam fıyatı gosterır
                SIPARISLER_YUKLE();
                label8.Text = "0";
                DataClass.DataClass.TOPLAM_FIYAT(comboBox3.SelectedValue.ToString(), "1", ref toplamfiyat);
                label5.Text = toplamfiyat.ToString();
            }
            catch
            {
                return;
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            //siparis oluturmak ıcın kullanılır
            if (numericUpDown1.Value != 0)
            {
                DataClass.DataClass.SIPARIS_DURUM_SORGU(comboBox3.SelectedValue.ToString(), comboBox3.Text, "1", ref durum);
                if (durum == true)
                {
                    DataClass.DataClass.SIPARIS_GONDER(comboBox3.SelectedValue.ToString(), comboBox3.Text, comboBox2.Text, numericUpDown1.Value.ToString(), toplam, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), 1, ref durum);
                    if (durum == true)
                    {
                        SIPARISLER_YUKLE();
                        TOPLAM_FIYAT();
                        MessageBox.Show("Sipariş oluşturuldu");
                    }
                    else
                    {
                        MessageBox.Show("Hata:Sipariş oluşturulamadı");
                    }
                }
                else
                {
                    MessageBox.Show("Hata:Sipariş oluşturulamadı");
                }
            }
            else
            {
                MessageBox.Show("Ürün sayısı 0 olamaz");
            }
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}