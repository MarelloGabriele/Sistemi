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
        bool loginValue = false; //true -> se ricevo l'ACK del server
        frmChat frm; //istanza form main
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
            if (!loginValue) //se voglio uscire senza aver ricevuto risposta
            {
                if (MessageBox.Show("Sei sicuro di uscire?", "Uscire?", MessageBoxButtons.YesNo) == DialogResult.Yes) //se sono sicuro di uscire
                {
                    frm.Close(); //killo il processo main e chiude tutto
                }
                else
                {
                    e.Cancel = true; //altrimenti ritorno a prima
                }
            }
            else //se ho ricevuto l'ACK
            {
                //apro il frm chat
                frm.Enabled = true; 
                frm.WindowState = FormWindowState.Normal;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            sendNickname(); //funzione che va ad inviare il nickname scritto
        }
        public void sendNickname()
        {
            string nickname = txtUsername.Text; //prendo il nickname scritto
            System.Threading.Thread.Sleep(5001); //attendo 5.001 sec (per accertarmi che io sia collegato al server

            //invio

            loginValue = true; //imposto login value a true
            this.Close(); //chiudo il tutto
        }
    }
}
