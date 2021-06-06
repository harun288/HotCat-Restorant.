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
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }
        //GLOBAL DEGISKENLER TANIMLADIM SUREKLI TANIMLAMAMAK ICIN
        Siparisler_Liste s = null;
        Masalar m = null;
        Ciro c = null;
        Tanimlar t = null;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (m == null || m.Disposing || m.IsDisposed)//CONTEINER ICINDE BU FORM ACILMISMI ACILMAMISMI KONTROL EDIYORUZ.CIFT ACILMALARI ENGELLEIYOR
            {
                //FORMU CONTEINER ICINDE ACIYOR
                m = new Masalar();
                m.MdiParent = this;
                m.Show();
            }
            else
            {
                m.Activate();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //CONTEINER ICINDE BU FORM ACILMISMI ACILMAMISMI KONTROL EDIYORUZ.CIFT ACILMALARI ENGELLEIYOR
           
                //FORMU CONTEINER ICINDE ACIYOR
            
        
            if (s == null || s.Disposing || s.IsDisposed)
            {
                s = new Siparisler_Liste();
                s.MdiParent = this;
                s.Show();
            }
            else
            {
                s.Activate();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //CONTEINER ICINDE BU FORM ACILMISMI ACILMAMISMI KONTROL EDIYORUZ.CIFT ACILMALARI ENGELLEIYOR

            //FORMU CONTEINER ICINDE ACIYOR
            
            if (c == null || c.Disposing || c.IsDisposed)
            {
                c = new Ciro();
                c.MdiParent = this;
                c.Show();
            }
            else
            {
                c.Activate();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //CONTEINER ICINDE BU FORM ACILMISMI ACILMAMISMI KONTROL EDIYORUZ.CIFT ACILMALARI ENGELLEIYOR

            //FORMU CONTEINER ICINDE ACIYOR
            
            if (t == null || t.Disposing || t.IsDisposed)
            {
                t = new Tanimlar();
                t.MdiParent = this;
                t.Show();
            }
            else
            {
                t.Activate();
            }
        }

        private void Anaform_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Siparisler s = new Siparisler();
            s.ShowDialog();
        }
    }
}
