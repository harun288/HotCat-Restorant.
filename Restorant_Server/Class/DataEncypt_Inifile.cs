using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;

namespace Restorant_Server.Class
{
  public  class DataEncypt_Inifile
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");


        public static string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new System.IO.MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
        public class RWIniFiles
        {

            string mvarstrIniFile = "";

            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section,
                string key, string val, string filePath);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section,
                string key, string def, StringBuilder retVal,
                int size, string filePath);


            public string ReadIni(string Section, string Key)
            {
                StringBuilder stbINI = new StringBuilder(255);
                GetPrivateProfileString(Section, Key, "", stbINI, 255, mvarstrIniFile);
                return stbINI.ToString();
            }
            public void WriteIni(string Section, string Key, string Value)
            {
                WritePrivateProfileString(Section, Key, Value, mvarstrIniFile);
            }
            public string IniFile
            {
                get { return mvarstrIniFile; }
                set { mvarstrIniFile = value; }
            }
        }
    }
}
