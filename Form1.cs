using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Boolean pathSet = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(quickOpen);

        }

        private void quickOpen(object sender, KeyPressEventArgs k)
        {
            if(pathSet && k.KeyChar == (char)Keys.Enter)
            {
                button2_Click(sender, k);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            label1.Text = openFileDialog1.FileName;
            this.pathSet = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
            openFileDialog1_FileOk(sender, null);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(openFileDialog1.FileName, textBox1.Text);


                X509Certificate2UI.DisplayCertificate(cert);
            }
            catch(System.Security.Cryptography.CryptographicException ex)
            {
                label4.Text = "Can't open certificate (bad password?) :\n" + ex.StackTrace;
            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
