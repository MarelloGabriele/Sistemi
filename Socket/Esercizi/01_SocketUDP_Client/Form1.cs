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

namespace _01_SocketUDP_Client
{
    public partial class Form1 : Form
    {
        static Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void btnAttivaDisattiva_Click(object sender, EventArgs e)
        {
            timer1.Enabled = (btnAttivaDisattiva.Text == "ATTIVA CLIENT");
            txtIPServer.Enabled = !timer1.Enabled;
            nudServerPort.Enabled = !timer1.Enabled;
            btnAttivaDisattiva.Text = (btnAttivaDisattiva.Text == "ATTIVA CLIENT" ? "DISATTIVA CLIENT" : "ATTIVA CLIENT");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                clsUDPClient clsUDPClient;
                clsMessage clsMsg = new clsMessage();
                clsUDPClient = new clsUDPClient(IPAddress.Parse(txtIPServer.Text), Convert.ToInt32(nudServerPort.Value));
                clsMsg.Messaggio = "CIAO";
                clsUDPClient.invia(clsMsg);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
