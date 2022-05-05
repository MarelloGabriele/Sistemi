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

namespace _02_SocketTCP_Client
{
    public partial class Form1 : Form
    {
        private clsTCPClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInvia_Click(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                clsMessage msg;
                client.invia(txtMsgInvio.Text);
                msg = client.ricevi();
                txtMsgRicevuti.Text += "[Data/Ora]" + msg.Ip + " : " + msg.Port + " - " + msg.Messaggio + Environment.NewLine;
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            impostaButton(true);
        }
        private void impostaButton(bool en)
        {
            btnStart.Enabled = en;
            btnStop.Enabled = !en;
            btnInvia.Enabled = !en;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            ip = clsAddress.findIP(txtServerIP.Text.ToString());
            // Istanza socket
            client = new clsTCPClient(ip, Convert.ToInt32(nudServerPort.Value));
            client.erroreConnessioneEvent += new erroreConnessioneEventHandler(visualizzaErrore);
            client.connetti();
        }

        private void visualizzaErrore(string msg)
        {
            MessageBox.Show(msg, this.Text);
            client.disconnetti();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            impostaButton(true);
            client.disconnetti();
        }
    }
}
