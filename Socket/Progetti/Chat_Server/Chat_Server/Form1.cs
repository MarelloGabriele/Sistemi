using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Server
{
    /* DOCUMENTAZIONE */
    // TRASMISSIONE --> UDP porta 27272
    //id 0 --> trasmissione nome e messaggio
    //id 1 --> indirizzo ip del server trasmesso in broadcast ogni 5 secondi
    //id 2 --> trasmissione di tutti gli utenti collegati ogni 30 secondi
    //id 3 --> vuoto, possibile futuro utilizzo
    // RICEZIONE --> TCP porta 27271
    //id 4 --> ricevo un messaggio e lo salvo
    //id 5 --> carico un username nella lista di quelli attivi

    public partial class Form1 : Form
    {
        public string ip_server; //stringa contenente indirizzo ip del server scelto dalla cmb
        clsServer server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dir = @"C:\ChatMarello";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            clsAddress.findIP(); //ricerco tutti gli IP disponibili
            cmbIP.DataSource = clsAddress.ipList; //carico gli IP restituiti
            btnStart.Enabled = true; //attivo il btn start
            btnStop.Enabled = false; //disattivo il btn stop
            server = new clsServer(); //istanzio la cls server
            /*server.scriviSuFileLog(1, "paolo", "luca", "ciao");
            server.scriviSuFileLog(1, "marco", "emanuele", "stronzo");
            server.scriviSuFileUser("antonio", "192.168.0.42");
            if (server.trovaUserInFile("antonio"))
            {
                server.scriviSuFileUser("antonio", "192.168.0.43");
            }
            server.scriviSuFileUser("luca", "192.168.0.65");
            */
            server.createSocket(); //richiamo la creazione dei socket
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            server.avvia();
            //viene eseguito un thread ogni 5 secondi che trasmette l'indirizzo IP del server in broadcast in modo che ogni
            //nuovo client possa riceverlo e collegarsi
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 5000; // in miliseconds
            timer1.Start(); //starto il timer
            //
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = 2000; // in miliseconds
            timer2.Start(); //starto il timer
            //
            btnStop.Enabled = true; //attivo il btn stop
            btnStart.Enabled = false; //disattivo il btn start
            //
            ip_server = cmbIP.SelectedItem.ToString(); //prendo l'IP desiderato
            cmbIP.Enabled = false; //disattivo la cmb
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            server.sendUdp(1, ip_server); //eseguo ID 1
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            server.sendUdp(2, ip_server); //eseguo ID 2
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.termina();
        }
        public void changeNUtenti()
        {
            BeginInvoke((MethodInvoker)delegate () {
                lblClient.Text = server.contClient.ToString();
            });
        }
        public void changeNMsg()
        {
            BeginInvoke((MethodInvoker)delegate () {
                lblMsgInviati.Text = server.contMsg.ToString();
            });
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"C:\ChatMarello");
        }
    }
}
