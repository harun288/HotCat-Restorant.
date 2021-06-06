using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Restorant_Server.Class;

namespace DataClass
{
   public static class DataClass
    {
        public static string server = "";
        public static string Database = "";
        public static string User = "";
        public static string Password = "";
        public static string enc = "";
        public static SqlConnection con;
        public static string Datemode = "";
        
        public static void dbconnection()
        {
            try
            {
                //verıtabanı bağlantısı kurma kodları
                DataEncypt_Inifile.RWIniFiles rwinifile = new DataEncypt_Inifile.RWIniFiles();
                rwinifile.IniFile = Application.StartupPath + @"\DBCONN.ini";
                server = rwinifile.ReadIni("DBCONN","Server");
                Database = rwinifile.ReadIni("DBCONN", "Database");
                User = rwinifile.ReadIni("DBCONN", "User").ToString();
                Password = DataEncypt_Inifile.Decrypt(rwinifile.ReadIni("DBCONN", "Password").ToString());
                con = new SqlConnection("data source='" + server + "';initial catalog='" + Database + "';User Id='" + User + "';Password='" + Password + "';");
              
            }
            catch
            {
                return;
            }
        }
        public static void URUN_TANIMLAMA(string GRUPADI, string URUNADI, string MIKTAR, double FIYAT,float TOPLAMFIYAT, ref bool durum)
        {
            try
            {

                dbconnection();
                SqlCommand com = new SqlCommand("insert URUNLER (GURUPADI,URUNADI,MIKTAR,BIRIMFIYAT,TOPLAMFIYAT) values(@GURUPADI,@URUNADI,@MIKTAR,@BIRIMFIYAT,@TOPLAMFIYAT)", con);
                com.Parameters.AddWithValue("@GURUPADI", GRUPADI);
                com.Parameters.AddWithValue("@URUNADI", URUNADI);
                com.Parameters.AddWithValue("@MIKTAR", MIKTAR);
                com.Parameters.AddWithValue("@BIRIMFIYAT", FIYAT);
                com.Parameters.AddWithValue("@TOPLAMFIYAT", TOPLAMFIYAT);
              
                con.Open();
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static void URUN_GUNCELLE(string ID,string GRUPADI, string URUNADI, string MIKTAR, double FIYAT,double TOPLAM, ref bool durum)
        {
            try
            {

                dbconnection();
                SqlCommand com = new SqlCommand("UPDATE URUNLER SET GURUPADI=@GURUPADI,URUNADI=@URUNADI,MIKTAR=@MIKTAR,BIRIMFIYAT=@BIRIMFIYAT,TOPLAMFIYAT=@TOPLAMFIYAT WHERE ID=@ID", con);
                com.Parameters.AddWithValue("@GURUPADI", GRUPADI);
                com.Parameters.AddWithValue("@URUNADI", URUNADI);
                com.Parameters.AddWithValue("@MIKTAR", MIKTAR);
                com.Parameters.AddWithValue("@BIRIMFIYAT", FIYAT);
                com.Parameters.AddWithValue("@TOPLAMFIYAT", TOPLAM);
                com.Parameters.AddWithValue("@ID", ID);

                con.Open();
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static System.Data.DataTable URUNLER_YUKLE()
        {

            dbconnection();
           

            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT ID,GURUPADI,URUNADI,MIKTAR,BIRIMFIYAT,TOPLAMFIYAT FROM URUNLER";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static int URUN_SIL(string id,ref bool durum)
        {
            try
            {
                dbconnection();
                SqlCommand com = new SqlCommand("DELETE URUNLER where ID=@ID");
                com.Parameters.AddWithValue("@ID", id);

                com.Connection = con;
                con.Open();
                int deger = com.ExecuteNonQuery();
                con.Close();
                durum = true;
                return deger;
            }
            catch
            {
                return -1;
            }
        }
        public static void KULLANICI(string KUL_AD, string SIFRE,ref bool durum)
        {
            try
            {
             

                dbconnection();
              
                SqlCommand command = new SqlCommand("select * from KULLANICI where KULLANICIADI=@KULLANICIADI and SIFRE=@SIFRE", con);
                command.Parameters.AddWithValue("@KULLANICIADI", KUL_AD);
                command.Parameters.AddWithValue("@SIFRE", SIFRE);
                con.Open();
                SqlDataReader sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    
                    durum = true;

                }

                else
                {
                    durum = false;

                }
            }
            catch
            {
                return;
            }
        }
        public static System.Data.DataTable ACIK_SIPARISLER()
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT MASAADI,SIPARISLER,FIYAT,TARIH FROM SIPARISLER WHERE MASA_DURUMU='1'";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable KAPALI_SIPARISLER()
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT MASAADI,SIPARISLER,FIYAT,TARIH FROM SIPARISLER WHERE MASA_DURUMU='0' ";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable RAPOR(string tarih1, string tarih2)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT MASAADI,SIPARISLER,FIYAT,TARIH FROM SIPARISLER WHERE TARIH BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND MASA_DURUMU='0'";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static void SIPARIS_TOPLAMI(string tarih1, string tarih2, ref float toplam)
        {
            try
            {

                  dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select sum(FIYAT) as [FIYAT] FROM SIPARISLER WHERE TARIH BETWEEN '" + tarih1 + "' AND '" + tarih2 + "'", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    toplam = Convert.ToSingle(dr["FIYAT"].ToString());
                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void TAHSILEDILEN_TOPLAMI(string tarih1, string tarih2, ref float toplam)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select sum(FIYAT) as [FIYAT] FROM SIPARISLER WHERE TARIH BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND MASA_DURUMU='0'" , con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    toplam = Convert.ToSingle(dr["FIYAT"].ToString());
                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA1(ref string MASA1,string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='"+MASANO+"' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA1 = dr["DURUM"].ToString();
                  
                    

                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA2(ref string MASA2, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA2 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA3(ref string MASA3, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA3 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA4(ref string MASA4, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA4 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA5(ref string MASA5, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA5 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA6(ref string MASA6, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA6 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA7(ref string MASA7, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA7 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA8(ref string MASA8, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA8 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA9(ref string MASA9, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA9 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA10(ref string MASA10, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA10 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA11(ref string MASA11, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA11 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA12(ref string MASA12, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA12 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA13(ref string MASA13, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA13 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA14(ref string MASA14, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA14 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA15(ref string MASA15, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA15 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA16(ref string MASA16, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA16 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA17(ref string MASA17, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA17 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA18(ref string MASA18, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA18 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA19(ref string MASA19, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA19 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_MASA20(ref string MASA20, string MASANO)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' ", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MASA20 = dr["DURUM"].ToString();



                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
      
     
     
       
        public static System.Data.DataTable SIPARIS_DETAY(string MASANO,string MASADURUM)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT SIPARIS_ID,MASANO,MASAADI,SIPARISLER,FIYAT,TARIH FROM SIPARISLER WHERE MASANO='"+MASANO+"' AND MASA_DURUMU='"+MASADURUM+"' ";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static void MASA_HESAPKAPAT(string MASANO,  ref bool durum)
        {
            try
            {

                dbconnection();
                SqlCommand com = new SqlCommand("UPDATE  SIPARISLER_DURUM SET DURUM=@DURUM WHERE MASANO=@MASANO", con);
               
                com.Parameters.AddWithValue("@MASANO", MASANO);
                com.Parameters.AddWithValue("@DURUM","0");



                con.Open();
                int deger = com.ExecuteNonQuery();
                durum = true;
               
             
                con.Close();
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static void MASA_SIPARISKAPAT(string MASANO, ref bool durum)
        {
            try
            {

                dbconnection();
                SqlCommand com = new SqlCommand("UPDATE  SIPARISLER SET MASA_DURUMU=@MASA_DURUMU WHERE MASANO=@MASANO AND MASA_DURUMU='" + 1 + "'", con);
               
                com.Parameters.AddWithValue("@MASANO", MASANO);
                com.Parameters.AddWithValue("@MASA_DURUMU","0");



                con.Open();
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static int URUN_IPTALI(string SIPARIS_ID, ref bool durum)
        {
            try
            {
                dbconnection();
                SqlCommand com = new SqlCommand("DELETE SIPARISLER where SIPARIS_ID=@SIPARIS_ID");
                com.Parameters.AddWithValue("@SIPARIS_ID", SIPARIS_ID);

                com.Connection = con;
                con.Open();
                int deger = com.ExecuteNonQuery();
                con.Close();
                durum = true;
                return deger;
            }
            catch
            {
                return -1;
            }
        }
        public static int TUM_SIPARIS_IPTAL(string MASANO,string MASAADI, ref bool durum)
        {
            try
            {
                dbconnection();
                SqlCommand com = new SqlCommand("DELETE SIPARISLER where MASANO=@MASANO AND MASA_DURUMU=@MASA_DURUMU");
                com.Parameters.AddWithValue("@MASANO",MASANO);
                com.Parameters.AddWithValue("@MASA_DURUMU", "1");

                com.Connection = con;
                con.Open();
                int deger = com.ExecuteNonQuery();
                con.Close();
                durum = true;
                MASA_HESAPKAPAT(MASANO,ref durum);
                durum = true;
                return deger;
            }
            catch
            {
                return -1;
            }
        }
        public static void SIPARIS_FIYATI(string MASAADI, string MASANO ,ref decimal toplam)
        {
            try
            {

                dbconnection();
                con.Open();
                SqlCommand com = new SqlCommand("select sum(FIYAT) as [FIYAT] FROM SIPARISLER WHERE MASAADI='"+MASAADI+"' AND MASANO='"+MASANO+"' AND MASA_DURUMU='1'", con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    toplam = Convert.ToDecimal(dr["FIYAT"].ToString());
                 
                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static System.Data.DataTable MASA_SELECT()
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *FROM MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static void MASA_INSERT(string MASAADI, ref bool durum)
        {
            try
            {

                dbconnection();
                SqlCommand com = new SqlCommand("insert MASALAR (MASAADI) values(@MASAADI)", con);
                com.Parameters.AddWithValue("@MASAADI", MASAADI);
             

                con.Open();
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static void MASA_UPDATE(string MASAADI,string ID ,ref bool durum)
        {
            try
            {

                dbconnection();
                SqlCommand com = new SqlCommand("update MASALAR set  MASAADI=@MASAADI WHERE ID=@ID", con);
                com.Parameters.AddWithValue("@MASAADI", MASAADI);
                com.Parameters.AddWithValue("@ID", ID);



                con.Open();
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static int MASA_DELETE(string MASAID, ref bool durum)
        {
            try
            {
                dbconnection();
                SqlCommand com = new SqlCommand("DELETE MASALAR where ID=@ID");
                com.Parameters.AddWithValue("@ID", MASAID);

                com.Connection = con;
                con.Open();
                int deger = com.ExecuteNonQuery();
                con.Close();
                durum = true;
                return deger;
            }
            catch
            {
                return -1;
            }
        }
        public static System.Data.DataTable MASA1_YUKLE(ref string MASA1)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);

          
                MASA1 = dtt.Rows[0][1].ToString();
           
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA2_YUKLE(ref  string MASA2)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);

         
            MASA2 = dtt.Rows[1][1].ToString();
           
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA3_YUKLE(ref  string MASA3)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA3 = dtt.Rows[2][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA4_YUKLE(ref  string MASA4)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA4 = dtt.Rows[3][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA5_YUKLE(ref  string MASA5)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA5 = dtt.Rows[4][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA6_YUKLE(ref  string MASA6)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA6 = dtt.Rows[5][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA7_YUKLE(ref  string MASA7)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA7 = dtt.Rows[6][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA8_YUKLE(ref  string MASA8)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA8 = dtt.Rows[7][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA9_YUKLE(ref  string MASA9)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA9= dtt.Rows[8][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA10_YUKLE(ref  string MASA10)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA10 = dtt.Rows[9][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA11_YUKLE(ref  string MASA11)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA11 = dtt.Rows[10][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA12_YUKLE(ref  string MASA12)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA12 = dtt.Rows[11][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA13_YUKLE(ref  string MASA13)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA13 = dtt.Rows[12][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA14_YUKLE(ref  string MASA14)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA14 = dtt.Rows[13][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA15_YUKLE(ref  string MASA15)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA15 = dtt.Rows[14][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA16_YUKLE(ref  string MASA16)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA16 = dtt.Rows[15][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA17_YUKLE(ref  string MASA17)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA17 = dtt.Rows[16][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA18_YUKLE(ref  string MASA18)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA18 = dtt.Rows[17][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA19_YUKLE(ref  string MASA19)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA19 = dtt.Rows[18][1].ToString();

            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASA20_YUKLE(ref  string MASA20)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT *from MASALAR";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);


            MASA20 = dtt.Rows[19][1].ToString();

            con.Close();
            return dtt;

        }
        public static void URUN_FIYAT(string ID, ref double FIYAT)
        {
            try
            {

                dbconnection();

                con.Open();
                SqlCommand com = new SqlCommand("SELECT *FROM URUNLER WHERE ID='" + ID + "'", con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {


                    FIYAT = Convert.ToDouble(dr["BIRIMFIYAT"].ToString());

                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_DURUM_SORGU(string MASANO, string MASAADI, string MASADURUM, ref bool durum)
        {
            try
            {

                dbconnection();

                con.Open();
                SqlCommand com = new SqlCommand("SELECT *FROM SIPARISLER_DURUM WHERE MASANO='" + MASANO + "' AND DURUM='0'", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {


                    SIPARIS_DURUM_UPDATE(MASANO, MASAADI, MASADURUM, ref durum);

                }
                else
                {
                    SIPARIS_DURUM(MASANO, MASAADI, MASADURUM, ref durum);
                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static void SIPARIS_DURUM(string MASANO, string MASAADI, string MASADURUM, ref bool durum)
        {
            try
            {

                dbconnection();

                SqlCommand com = new SqlCommand("insert SIPARISLER_DURUM (MASANO,MASAADI,DURUM) values(@MASANO,@MASAADI,@DURUMU)", con);
                com.Parameters.AddWithValue("@MASANO", MASANO);
                com.Parameters.AddWithValue("@MASAADI", MASAADI);
                com.Parameters.AddWithValue("@DURUMU", MASADURUM);

                con.Open();
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch
            {
                durum = false;
                return;
            }
        }
      
        public static void SIPARIS_DURUM_UPDATE(string MASANO, string MASAADI, string MASADURUM, ref bool durum)
        {
            try
            {

                dbconnection();

                SqlCommand com = new SqlCommand("UPDATE  SIPARISLER_DURUM SET MASANO=@MASANO,MASAADI=@MASAADI,DURUM=@DURUM WHERE MASANO='" + MASANO + "' AND DURUM='0'", con);
                com.Parameters.AddWithValue("@MASANO", MASANO);
                com.Parameters.AddWithValue("@MASAADI", MASAADI);
                com.Parameters.AddWithValue("@DURUM", MASADURUM);

                con.Open();
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static System.Data.DataTable ACIK_SIPARIS_GETIR(string MASANO, string MASADURUM)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT SIPARISLER,SIPARIS_ADET,FIYAT FROM SIPARISLER WHERE MASANO='" + MASANO + "' AND MASA_DURUMU='" + MASADURUM + "'";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static void SIPARIS_GONDER(string MASANO, string MASAADI, string SIPARISLER, string ADET, decimal FIYAT, DateTime TARIH, int MASADURUM, ref bool durum)
        {
            try
            {

                dbconnection();

                SqlCommand com = new SqlCommand("insert SIPARISLER (MASANO,MASAADI,SIPARISLER,SIPARIS_ADET,FIYAT,TARIH,MASA_DURUMU) values(@MASANO,@MASAADI,@SIPARISLER,@SIPARIS_ADET,@FIYAT,@TARIH,@MASA_DURUMU)", con);
                com.Parameters.AddWithValue("@MASANO", MASANO);
                com.Parameters.AddWithValue("@MASAADI", MASAADI);
                com.Parameters.AddWithValue("@SIPARISLER", SIPARISLER);
                com.Parameters.AddWithValue("@SIPARIS_ADET", ADET);
                com.Parameters.AddWithValue("@FIYAT", FIYAT);
                com.Parameters.AddWithValue("@TARIH", TARIH);
                com.Parameters.AddWithValue("@MASA_DURUMU", MASADURUM);

                con.Open();
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static void TOPLAM_FIYAT(string MASANO, string MASADURUM, ref decimal FIYAT)
        {
            try
            {

                dbconnection();

                con.Open();
                SqlCommand com = new SqlCommand("SELECT SUM(FIYAT)AS[FIYAT] FROM SIPARISLER WHERE MASANO='" + MASANO + "' AND MASA_DURUMU='" + MASADURUM + "'", con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {


                    FIYAT = Convert.ToDecimal(dr["FIYAT"].ToString());

                }
                con.Close();


            }
            catch
            {

                return;
            }
        }
        public static System.Data.DataTable URUN_GURUP()
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT GURUPADI FROM URUNLER GROUP BY GURUPADI";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable MASALAR()
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT * FROM MASALAR ";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable URUNLER(string GURUPADI)
        {

            dbconnection();


            System.Data.DataTable dtt = new System.Data.DataTable();
            con.Open();
            string comstring = "SELECT URUNADI,ID FROM URUNLER WHERE GURUPADI='" + GURUPADI + "'";
            SqlDataAdapter daa = new SqlDataAdapter(comstring, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
    }
}
