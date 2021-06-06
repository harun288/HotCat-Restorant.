using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Restorant_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool durum;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        public void giris()
        {
            try
            {
                if (textEdit1.Text == "" || textEdit2.Text == "")
                {
                    MessageBox.Show("Alanları Doldurunuz!!!");
                }
                else
                {
                    //kullanıcının var olup olmadıgını kontrol eden kod
                    DataClass.DataClass.KULLANICI(textEdit1.Text, textEdit2.Text, ref durum);
                    if (durum == true)
                    {
                        //eger var ve dogru ıse allatakı koda gecer bu kod anaformumuzu acar
                        Anaform a = new Anaform();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz Kullanıcı");
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //butonla gırıs
            giris();
        }

       

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //sifreyı yazdıktan sonrakı enterla gırıs
                giris();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //eger database ayarlanmamıssa database ayar formı acılcak
            if (!File.Exists(Application.StartupPath + @"\DBCONN.ini"))
            {
                database db = new database();
                db.ShowDialog();

            }
        }
    }
}
