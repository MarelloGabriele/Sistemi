using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_SocketTCP_Server
{
    public delegate void aggiornaInterfacciaGraficaDatiHandler(clsMessage msg);
    public delegate void aggiornaStatoEventHandler(string msg);
    
    public partial class Form1 : Form
    {
        private clsTCPServer server;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            ip = clsAddress.ipList[cmbServerIp.SelectedIndex];
            server = new clsTCPServer(ip, Convert.ToInt32(nudServerPort.Value));
            server.datiRicevutiEvent += new datiRicevutiHandler(datiRicevuti);
            server.erroreConnessioneEvent += new erroreConnessioneEventHandler(visualizzaErrore);
            server.statoConnessioneEvent += new statoConnessioneEventHandler(visualizzaStato);
            server.avvia();
            /* GESTIONE BOTTONI */
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void datiRicevuti(clsMessage msg)
        {
            aggiornaInterfacciaGraficaDatiHandler pt = new aggiornaInterfacciaGraficaDatiHandler(aggiornaGrafica);
            this.Invoke(pt, msg);
            // Server rispond al client
            server.invia("ACK");
            // testa Coda Client
            if (MessageBox.Show("Continuo a ricevere dal client?", "",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                server.chiudiConnessione();
            }
        }

        private void aggiornaGrafica(clsMessage msg)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                txtMsgRicevuti.Text += msg.Ip + " : " + msg.Port + " - " + msg.Messaggio + Environment.NewLine;
            });
        }

        private void visualizzaStato(string msg)
        {
            Console.WriteLine("ERRORE STATO: " + msg);
        }

        private void visualizzaErrore(string msg)
        {
            aggiornaStatoEventHandler pt = new aggiornaStatoEventHandler(visualizzaStato);
            this.Invoke(pt, msg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsAddress.findIP();
            cmbServerIp.DataSource = clsAddress.ipList;

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                server.chiudi();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.chiudi();
            server = null;
            /* GESTIONE BOTTONI */
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            cmbServerIp.Enabled = true;
        }
    }
}
