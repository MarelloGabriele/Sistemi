using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client
{
    public partial class frmChat : Form
    {
        internal string nome_utente = "";
        internal string indirizzo_server = "";
        public frmChat()
        {
            InitializeComponent();
            clsGrafica.setDgvChat(dgvChat);
            clsGrafica.setDgvUtenti(dgvListaUtenti);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            frmLoadFile  frm = new frmLoadFile();
            frm.Show();  
        }

        private void dgvChat_SelectionChanged(object sender, EventArgs e)
        {
            dgvChat.ClearSelection();
        }

        private void btnInviaMsg_Click(object sender, EventArgs e)
        {
            dgvChat.Rows.Add();
        }

        private void dgvChat_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvChat.FirstDisplayedScrollingRowIndex = dgvChat.Rows.Count - 1;
        }

        private void frmChat_Load(object sender, EventArgs e)
        {
            
            Thread th = new Thread(getIndirizzo);
            th.Start();
            th.Abort();
            frmLogin frmLogin = new frmLogin(this);
            frmLogin.Show();
            frmLogin.BringToFront();
            this.WindowState = FormWindowState.Minimized;
            this.Enabled = false;
        }

        private void getIndirizzo()
        {
            while (indirizzo_server == "")
                indirizzo_server = clsClient.cercaServer();
        }
    }
}
