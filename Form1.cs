using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int sayac = 0;
        public string kapatStr = "/C NetSh Advfirewall set allprofiles state off";
        public string acStr = "/C NetSh Advfirewall set allprofiles state on";
        public string durumKontrolStr = "/C Netsh Advfirewall show allprofiles";
        public void GuvenlikDuvariKapat()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //cmd gizli başlasın!
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = kapatStr;
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();           
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GuvenlikDuvariKapat();
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            label1.Text = sayac.ToString();
            if (sayac == 3)
            {
                timer1.Stop();
                this.Hide();
            }
        }
    }
}
