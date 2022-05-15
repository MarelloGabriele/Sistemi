using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client
{
    public partial class frmLogin : Form
    {
        bool loginValue = false;
        frmChat frm;
        public frmLogin(frmChat frm)
        {
            InitializeComponent();
            this.frm = frm; 
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loginValue)
            {
                if (MessageBox.Show("Sei sicuro di uscire?", "Uscire?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frm.Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                frm.Enabled = true;
                frm.WindowState = FormWindowState.Normal;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            sendNickname();
        }
        public void sendNickname()
        {
            string nickname = txtUsername.Text;
            System.Threading.Thread.Sleep(1000);
            


            this.Close();
        }
    }
}
