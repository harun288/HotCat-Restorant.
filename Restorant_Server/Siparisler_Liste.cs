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
    public partial class Siparisler_Liste : Form
    {
        public Siparisler_Liste()
        {
            InitializeComponent();
        }

        private void Siparisler_Load(object sender, EventArgs e)
        {
            try
            {
                //acık ve kapalı sıparıslerı yukler
                gridView1.GroupPanelText = "Verileri guruplamak için kolonları sürükleyin";
                gridView2.GroupPanelText = "Verileri guruplamak için kolonları sürükleyin";
             
                   gridControl1.DataSource= DataClass.DataClass.ACIK_SIPARISLER();
               
                   gridControl2.DataSource=DataClass.DataClass.KAPALI_SIPARISLER();
                
            }
            catch
            {
                return;
            }
        }
    }
}
