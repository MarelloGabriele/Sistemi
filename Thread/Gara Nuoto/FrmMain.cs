using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; 

namespace LabGaraNuoto
{
    public partial class FrmMain : Form
    {
        volatile Random rnd;
        volatile int atletiLetti; 
        Thread arbitro; 
        volatile Dictionary<string, int> atleti = new Dictionary<string, int>(); 
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("atleti.txt");
            string line;
            lblAtleti.Text = "";
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                atleti.Add(line, 1); 
            }
            sr.Close();
            stampaAtletiResidui();
            atletiLetti = atleti.Count; 
        }

        private void stampaAtletiResidui()
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                lblAtleti.Text = ""; 
                for(int i=0; i<atleti.Count; i++)
                {
                    if( atleti.ElementAt(i).Value == 1)
                        lblAtleti.Text += atleti.ElementAt(i).Key.ToString() + Environment.NewLine;
                }
            });
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            lblEsito.Text = ""; // Label finalisti 
            lblEliminati.Text = "";  // Label eliminati 
            arbitro = new Thread(arbitroThread);
            arbitro.Start();
        }

        private void arbitroThread()
        {
            int atletiResidui = atletiLetti;
            int turno = 0; 
            while (atletiResidui > 0)
            {
                setValore(lblTurno, "TURNO: " + (++turno).ToString());
                eseguiGara();
                atletiResidui -= 4; 
            }
            MessageBox.Show("ELIMINATORIE TERMINATE"); 
        }

        private void eseguiGara()
        {

        }

        private void setValore(Label lbl, string msg)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
               lbl.Text = msg;
            });
        }
    }
}
