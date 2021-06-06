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
    public partial class Masalar : Form
    {
        public Masalar()
        {
            InitializeComponent();
        }
        string MASA1 = "";
        string MASA2 = "";
        string MASA3 = "";
        string MASA4 = "";
        string MASA5 = "";
        string MASA6 = "";
        string MASA7 = "";
        string MASA8 = "";
        string MASA9 = "";
        string MASA10 = "";
        string MASA11 = "";
        string MASA12 = "";
        string MASA13 = "";
        string MASA14 = "";
        string MASA15 = "";
        string MASA16 = "";
        string MASA17 = "";
        string MASA18 = "";
        string MASA19 = "";
        string MASA20 = "";
      /// <summary>
      /// 
      /// </summary>
        ///  
        string MASA1x = "";
        string MASA2x = "";
        string MASA3x = "";
        string MASA4x = "";
        string MASA5x = "";
        string MASA6x= "";
        string MASA7x = "";
        string MASA8x = "";
        string MASA9x = "";
        string MASA10x = "";
        string MASA11x = "";
        string MASA12x = "";
        string MASA13x = "";
        string MASA14x = "";
        string MASA15x = "";
        string MASA16x = "";
        string MASA17x = "";
        string MASA18x = "";
        string MASA19x = "";
        string MASA20x = "";
        Siparis_Detay sd = null;
        DataEncypt_Inifile.RWIniFiles inifiles = new DataEncypt_Inifile.RWIniFiles();
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton6.Text;
                sd.MASANO = "M12";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton1.Text;
                sd.MASANO = "M1";
             
             
                    sd.ShowDialog();

                
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
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton2.Text;
                sd.MASANO = "M2";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton4.Text;
                sd.MASANO = "M3";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton8.Text;
                sd.MASANO = "M4";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton9.Text;
                sd.MASANO = "M5";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton10.Text;
                sd.MASANO = "M6";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text =simpleButton11.Text;
                sd.MASANO = "M7";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton12.Text;
                sd.MASANO = "M8";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton13.Text;
                sd.MASANO = "M9";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton14.Text;
                sd.MASANO = "M10";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text =simpleButton16.Text;
                sd.MASANO = "M11";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton15.Text;
                sd.MASANO = "M13";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text =simpleButton17.Text;
                sd.MASANO = "M14";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text =simpleButton18.Text;
                sd.MASANO = "M15";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton19.Text;
                sd.MASANO = "M16";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton20.Text;
                sd.MASANO = "M17";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton7.Text;
                sd.MASANO = "M18";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton3.Text;
                sd.MASANO = "M19";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                //siparis detay formumuzu acmak ve masaadımızı ile masanomuzu siparis detay formuna gondermek ıcın kullandıgımız kodlar
                // masano "M1"ve ustlerı yazan kısımları asla degısırme 
                sd = new Siparis_Detay();
                sd.label3.Text = simpleButton5.Text;
                sd.MASANO = "M20";
                sd.ShowDialog();
            }
            catch
            {
                return;
            }
        }
      
    
        private void Masalar_Load(object sender, EventArgs e)
        {
          //ilk açılışta işleyen kodlar
            MASADURUMLARI();
            MASAISIMLERI();
            timer1.Enabled = true;
            timer1.Interval = 1000;
          
        }
      public  void MASADURUMLARI()
        {
            // masalara gelen verı 1 ise dolu 0 ise bostur
            //1.masa
            DataClass.DataClass.SIPARIS_MASA1(ref MASA1,"M1");
            if (MASA1 == "1")
            {
                //masa durumunun 1 oldugu zamanlarda allatakı kod devreye gırerek buton resmını degıtırır
                simpleButton1.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA1 == "0" || MASA1=="")
            {
                simpleButton1.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //2.masa
            DataClass.DataClass.SIPARIS_MASA2(ref MASA2, "M2");
            if (MASA2 == "1")
            {
                simpleButton2.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA2 == "0" || MASA2 == "")
            {
                simpleButton2.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //3.masa
            DataClass.DataClass.SIPARIS_MASA3(ref MASA3, "M3");
            if (MASA3 == "1")
            {
                simpleButton4.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA3 == "0" || MASA3 == "")
            {
                simpleButton4.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //4.masa
            DataClass.DataClass.SIPARIS_MASA4(ref MASA4, "M4");
            if (MASA4 == "1")
            {
                simpleButton8.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA4 == "0" || MASA4 == "")
            {
                simpleButton8.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //5.masa
            DataClass.DataClass.SIPARIS_MASA5(ref MASA5, "M5");
            if (MASA5 == "1")
            {
                simpleButton9.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA5 == "0" || MASA5 == "")
            {
                simpleButton9.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //6.masa
            DataClass.DataClass.SIPARIS_MASA6(ref MASA6, "M6");
            if (MASA6 == "1")
            {
                simpleButton10.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA6 == "0" || MASA6 == "")
            {
                simpleButton10.Image = global::Restorant_Server.Properties.Resources.desktop;
            }

            //7.masa
            DataClass.DataClass.SIPARIS_MASA7(ref MASA7, "M7");
            if (MASA7 == "1")
            {
                simpleButton11.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA7 == "0" || MASA7 == "")
            {
                simpleButton11.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //8.masa
            DataClass.DataClass.SIPARIS_MASA8(ref MASA8, "M8");
            if (MASA8 == "1")
            {
                simpleButton12.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA8 == "0" || MASA8 == "")
            {
                simpleButton12.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //9.masa
            DataClass.DataClass.SIPARIS_MASA9(ref MASA9,"M9");
            if (MASA9 == "1")
            {
                simpleButton13.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA9 == "0" || MASA9 == "")
            {
                simpleButton13.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //10.masa
            DataClass.DataClass.SIPARIS_MASA10(ref MASA10, "M10");
            if (MASA10 == "1")
            {
                simpleButton14.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA10 == "0" || MASA10 == "")
            {
                simpleButton14.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //11.masa
            DataClass.DataClass.SIPARIS_MASA11(ref MASA11,"M11");
            if (MASA11 == "1")
            {
                simpleButton16.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA11 == "0" || MASA11 == "")
            {
                simpleButton16.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //12.masa
            DataClass.DataClass.SIPARIS_MASA12(ref MASA12,"M12");
            if (MASA12 == "1")
            {
                simpleButton6.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA12 == "0" || MASA12 == "")
            {
                simpleButton6.Image = global::Restorant_Server.Properties.Resources.desktop;
            }

            //13.masa
            DataClass.DataClass.SIPARIS_MASA13(ref MASA13, "M13");
            if (MASA13 == "1")
            {
                simpleButton15.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA13 == "0" || MASA13 == "")
            {
                simpleButton15.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //14.masa
            DataClass.DataClass.SIPARIS_MASA14(ref MASA14,"M14");
            if (MASA14 == "1")
            {
                simpleButton17.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA14 == "0" || MASA14 == "")
            {
                simpleButton17.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //15.masa
            DataClass.DataClass.SIPARIS_MASA15(ref MASA15, "M15");
            if (MASA15 == "1")
            {
                simpleButton18.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA15 == "0" || MASA15 == "")
            {
                simpleButton18.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //16.masa
            DataClass.DataClass.SIPARIS_MASA16(ref MASA16, "M16");
            if (MASA16 == "1")
            {
                simpleButton19.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA16 == "0" || MASA16 == "")
            {
                simpleButton19.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //17.masa
            DataClass.DataClass.SIPARIS_MASA17(ref MASA17, "M17");
            if (MASA17 == "1")
            {
                simpleButton20.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA17 == "0" || MASA17 == "")
            {
                simpleButton20.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //18.masa
            DataClass.DataClass.SIPARIS_MASA18(ref MASA18,"M18");
            if (MASA18 == "1")
            {
                simpleButton7.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA18 == "0" || MASA18 == "")
            {
                simpleButton7.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //19.masa
            DataClass.DataClass.SIPARIS_MASA19(ref MASA19,"M19");
            if (MASA19 == "1")
            {
                simpleButton3.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA19 == "0" || MASA19 == "")
            {
                simpleButton3.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
            //20.masa
            DataClass.DataClass.SIPARIS_MASA20(ref MASA20, "M20");
            if (MASA20 == "1")
            {
                simpleButton5.Image = global::Restorant_Server.Properties.Resources.users;
            }
            if (MASA20 == "0" || MASA20 == "")
            {
                simpleButton5.Image = global::Restorant_Server.Properties.Resources.desktop;
            }
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            MASADURUMLARI();
        }
        //ASADAKI KODLAR MASA ISIMLERINI CEKMEMIZ ICIN KULLANILIR
        public void MASAISIMLERI()
        {
          
                try
                {
                    DataClass.DataClass.MASA1_YUKLE(ref MASA1x);
                    simpleButton1.Text = MASA1x;
                    DataClass.DataClass.MASA2_YUKLE(ref MASA2x);
                    simpleButton2.Text = MASA2x;
                    DataClass.DataClass.MASA3_YUKLE(ref MASA3x);
                    simpleButton4.Text = MASA3x;
                    DataClass.DataClass.MASA4_YUKLE(ref MASA4x);
                    simpleButton8.Text = MASA4x;
                    DataClass.DataClass.MASA5_YUKLE(ref MASA5x);
                    simpleButton9.Text = MASA5x;
                    DataClass.DataClass.MASA6_YUKLE(ref MASA6x);
                    simpleButton10.Text = MASA6x;
                    DataClass.DataClass.MASA7_YUKLE(ref MASA7x);
                    simpleButton11.Text = MASA7x;
                    DataClass.DataClass.MASA8_YUKLE(ref MASA8x);
                    simpleButton12.Text = MASA8x;
                    DataClass.DataClass.MASA9_YUKLE(ref MASA9x);
                    simpleButton13.Text = MASA9x;

                    DataClass.DataClass.MASA10_YUKLE(ref MASA10x);
                    simpleButton14.Text = MASA10x;
                    DataClass.DataClass.MASA11_YUKLE(ref MASA11x);
                    simpleButton16.Text = MASA11x;
                    DataClass.DataClass.MASA12_YUKLE(ref MASA12x);
                    simpleButton6.Text = MASA12x;
                    DataClass.DataClass.MASA13_YUKLE(ref MASA13x);
                    simpleButton15.Text = MASA13x;
                    DataClass.DataClass.MASA14_YUKLE(ref MASA14x);
                    simpleButton17.Text = MASA14x;
                    DataClass.DataClass.MASA15_YUKLE(ref MASA15x);
                    simpleButton18.Text = MASA15x;
                    DataClass.DataClass.MASA16_YUKLE(ref MASA16x);
                    simpleButton19.Text = MASA16x;
                    DataClass.DataClass.MASA17_YUKLE(ref MASA17x);
                    simpleButton20.Text = MASA17x;
                    DataClass.DataClass.MASA18_YUKLE(ref MASA18x);
                    simpleButton7.Text = MASA18x; 
                    DataClass.DataClass.MASA19_YUKLE(ref MASA19x);
                    simpleButton3.Text = MASA19x;
                    DataClass.DataClass.MASA20_YUKLE(ref MASA20x);
                    simpleButton5.Text = MASA20x;
                }
                catch
                {
                    return;
                }
              

           
        }

       
    }
}
