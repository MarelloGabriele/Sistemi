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
        internal string nome_utente = ""; //str che contiene il nickname in modo da poterlo usare dopo per vari controlli
        internal string indirizzo_server = ""; //str che contiene l'indirizzo fisso del server 
        public frmChat()
        {
            InitializeComponent();
            clsGrafica.setDgvChat(dgvChat); //funzione che gestisce la grafica del dgvChat
            clsGrafica.setDgvUtenti(dgvListaUtenti); //funzione che gestisce la grafica del dgvUtenti
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            frmLoadFile  frm = new frmLoadFile(); 
            frm.Show();  //apro la form che contiene i bottoni per il caricamento dei vari file, vengo inviati in p2p
        }

        private void dgvChat_SelectionChanged(object sender, EventArgs e)
        {
            dgvChat.ClearSelection(); //toglie lo sfondo azzurro nelle celle selezionate
        }

        private void btnInviaMsg_Click(object sender, EventArgs e)
        {
            dgvChat.Rows.Add(); //ogni volta che mando un msg aggiunge una riga in automatico
        }

        private void dgvChat_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvChat.FirstDisplayedScrollingRowIndex = dgvChat.Rows.Count - 1; //quando ricevo o invio un nuovo messaggio scorro verso il basso la dgv
        }

        private void frmChat_Load(object sender, EventArgs e)
        {
            
            Thread th = new Thread(getIndirizzo); //creo un thread che si occupa di mettersi in ascolto e ricevere l'indirizzo del server
            th.Start(); //avvio il thread
            th.Abort(); //stoppo il thread quando ha finito
            frmLogin frmLogin = new frmLogin(this); //istanzio una form che si occupa del login
            frmLogin.Show(); //mostro la form login
            frmLogin.BringToFront(); //in primo piano
            this.WindowState = FormWindowState.Minimized; //riduco ad icona la frm della chat
            this.Enabled = false; //la disattivo
        }

        private void getIndirizzo()
        {
            while (indirizzo_server == "") //vado avanti fino a quando non ricevo l'indirizzo, max 5s se sono collegato alla rete
                indirizzo_server = clsClient.cercaServer();
        }
    }
}
