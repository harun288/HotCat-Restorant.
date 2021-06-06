using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Microsoft.Office.Interop.Excel;

namespace Restorant_Server
{
    public partial class Ciro : Form
    {
        public Ciro()
        {
            InitializeComponent();
        }
        float siparistoplam = 0;
        float tahsiltoplam = 0;
        private void Ciro_Load(object sender, EventArgs e)
        {
            try
            {
                //gridviewoanel texti düzenler
                gridView1.GroupPanelText = "Verileri guruplamak için kolonları sürükleyin";

                //tarih textlerinde bugunun tarıhını gostermekte kullanılır
                dateEdit1.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                dateEdit2.Text = DateTime.Now.ToShortDateString();
            }
            catch
            {
                return;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dateEdit1.DateTime > dateEdit2.DateTime)
                {
                    //burda ılk tarıh son tarıhten buyuk olamaz kuralını uyguladık
                    MessageBox.Show("İlk tarih son tarihten büyük olamaz");

                }
                else
                {
                    //bu kısımda raporlama yapıyoruz.
                    if (checkEdit1.Checked == false)
                    {
                       //bu kısımda normal tarıhsel raporlama yapıyoruz
                        gridControl1.DataSource = DataClass.DataClass.RAPOR(dateEdit1.DateTime.ToString("yyyy-MM-dd 00:00:00"), dateEdit2.DateTime.AddDays(+1).ToString("yyyy-MM-dd 00:00:00"));
                        DataClass.DataClass.SIPARIS_TOPLAMI(dateEdit1.DateTime.ToString("yyyy-MM-dd 00:00:00"), dateEdit2.DateTime.AddDays(+1).ToString("yyyy-MM-dd 00:00:00"), ref siparistoplam);
                        label6.Text = siparistoplam.ToString() + "TL";
                        DataClass.DataClass.TAHSILEDILEN_TOPLAMI(dateEdit1.DateTime.ToString("yyyy-MM-dd 00:00:00"), dateEdit2.DateTime.AddDays(+1).ToString("yyyy-MM-dd 00:00:00"), ref tahsiltoplam);
                        label7.Text = tahsiltoplam.ToString()+"TL";
                       
                        float satısacik = 0;
                        satısacik = siparistoplam - tahsiltoplam;
                        label8.Text = satısacik.ToString() + "TL";
                    }
                    if (checkEdit1.Checked == true)
                    {
                        //bu kısımda bugunu raporla dedıgımız kutucuk ıslevı devereye gırıyor
                        gridControl1.DataSource = DataClass.DataClass.RAPOR(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                       //siparis toplamını hesaplayana kısım
                        DataClass.DataClass.SIPARIS_TOPLAMI(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), ref siparistoplam);
                        label6.Text = siparistoplam.ToString() + "TL";
                        //tahsıl edılenı hesaplayan kod
                        DataClass.DataClass.TAHSILEDILEN_TOPLAMI(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), ref tahsiltoplam);
                        label7.Text = tahsiltoplam.ToString() + "TL";
                        float satısacik = 0;
                        //satıs acıgını hesaplayan kod
                        satısacik = siparistoplam - tahsiltoplam;
                        label8.Text = satısacik.ToString() + "TL";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hata:Rapor sunulamıyor");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //exele akratma kodları
                this.Enabled = false;


                ApplicationClass excel = new ApplicationClass();

                object Missing = Type.Missing;
                Workbook workbook = excel.Workbooks.Add(Missing);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                int StartCol = 1;
                int StartRow = 1;
                for (int j = 0;
                    j < gridView1.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = gridView1.Columns[j].Caption;
                } StartRow++;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    for (int j = 0; j < gridView1.Columns.Count; j++)
                    {
                        try
                        {
                            //rowları sayıyıoruz sonrada columları sayıyoruz ve exele gonderıyoruz

                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = gridView1.GetRowCellValue(i, gridView1.Columns[j]).ToString() == null ? "" : gridView1.GetRowCellValue(i, gridView1.Columns[j]).ToString();
                            myRange.Select();
                        }

                        catch
                        {
                            return;
                        }
                    }
                }

                excel.Visible = true;
                this.Enabled = true;

            }
            catch
            {
                return;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //yazdırma secengegı
            printableComponentLink1.ShowPreview();
        }
      
       
    }
}
