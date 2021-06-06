using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restorant_Server
{
    public partial class database : Form
    {
        public database()
        {
            InitializeComponent();
        }
        public static string server = "";
        public static string Database = "";
        public static string User = "";
        public static string Password = "";
        public static string dencription(string denc)
        {

            byte[] encodedDataAsBytes = System.Convert.FromBase64String(denc);
            return System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

        }
        string DS = "";
        string IC = "";
        string UID = "";
        string PSS = "";
        bool durum;
        SqlConnection baglanti = new SqlConnection();
        public static string conn_string;
        void bağlan()
        {
            try
            {

                DS = "Data Source='" + textEdit1.Text + "';";
                IC = "Initial Catalog='" + textEdit2.Text + "';";
                UID = "UID='" + textEdit3.Text + "';";
                PSS = "password='" + textEdit4.Text + "';";
                conn_string = DS + IC + UID + PSS;
                baglanti.ConnectionString = conn_string;
                baglanti.Open();
                bool onay;
                onay = Convert.ToBoolean(baglanti.State);

                MessageBox.Show("Bağlantı Testi Başarılı");
                durum = true;
            }
            catch
            {

                MessageBox.Show("Bağlantı başarısız");
                durum = false;
            }

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            try
            {
                if (textEdit1.Text == "" || textEdit2.Text == "" || textEdit3.Text == "" || textEdit4.Text == "")
                {
                    MessageBox.Show("Tüm (*) alanları doldurun");
                }
                else
                {

                    bağlan();
                    if (durum != false)
                    {
                        Restorant_Server.Class.DataEncypt_Inifile.RWIniFiles inifiles = new Restorant_Server.Class.DataEncypt_Inifile.RWIniFiles();
                        inifiles.IniFile = Application.StartupPath + @"\DBCONN.ini";
                        inifiles.WriteIni("DBCONN", "Server", textEdit1.Text);
                        inifiles.WriteIni("DBCONN", "Database", textEdit2.Text);
                        inifiles.WriteIni("DBCONN", "User", textEdit3.Text);
                        inifiles.WriteIni("DBCONN", "Password", Restorant_Server.Class.DataEncypt_Inifile.Encrypt(textEdit4.Text));
                        this.Close();
                    }

                }
            }
            catch
            {
                return;
            }
        }

        private void database_Load(object sender, EventArgs e)
        {
            try
            {
                Restorant_Server.Class.DataEncypt_Inifile.RWIniFiles inifiles = new Restorant_Server.Class.DataEncypt_Inifile.RWIniFiles();
                inifiles.IniFile = Application.StartupPath + @"\DBCONN.ini";
                server = inifiles.ReadIni("DBCONN", "Server").ToString();
                Database = inifiles.ReadIni("DBCONN", "Database").ToString();
                User = inifiles.ReadIni("DBCONN", "User").ToString();
                Password = Restorant_Server.Class.DataEncypt_Inifile.Decrypt(inifiles.ReadIni("DBCONN", "Password").ToString());
                textEdit1.Text = server;
                textEdit2.Text = Database;
                textEdit3.Text = User;
                textEdit4.Text = "";
            }
            catch
            {
                return;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}
