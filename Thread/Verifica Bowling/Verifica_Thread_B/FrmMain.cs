using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verifica_Thread_B
{
    public partial class FrmMain : Form
    {
        const int PALLA_INIZIO_X = 400;
        const int PALLA_FINE_X = 20;
        const int TIRI = 2;
        const int CORSIE = 4;
        object lock_campo = new object(); 
        volatile Random rnd; 
        volatile Dictionary<string, int> giocatori = new Dictionary<string, int>();
        volatile int totaleGiocatori; // Totale giocatori presenti nel file 
        volatile int nGioc; // Giocatori Effettivi 
        volatile int[] puntiGiocatori; // Array parallelo al dictionary per gestire il punteggio 
        Thread arbitro;
        Thread[] thArbCampo; // Thread gestori del campo 
        Thread[] thCampo; // Giocatore impegnato nella gara 
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("giocatori.txt");
            int cnt = 0;
            while (!sr.EndOfStream)
            {
                //sr.ReadLine();
                giocatori.Add(sr.ReadLine(), 0); // Tutti i giocatori presenti nel file 
                cnt++;
            }
            sr.Close();
            nUDpartecipanti.Maximum = cnt; // Massimo numero numericUpDown
            puntiGiocatori = new int[cnt]; 
            totaleGiocatori = cnt; 
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            /* Recupero partecipanti effettivi */
            nGioc = Convert.ToInt32(nUDpartecipanti.Value);
            /* Avvio arbitro : main thread */
            arbitro = new Thread(gestoreTorneo); 
            arbitro.Start();
        }

        private void gestoreTorneo()
        {
            thArbCampo = new Thread[CORSIE];
            thCampo = new Thread[CORSIE]; 

            int posGioc; // Posizione del giocatore estratto 
            // Estraggo giocatori partecipanti al torneo 
            for(int i=0; i<nGioc; i++)
            {
                do
                {
                    posGioc = rnd.Next(0, totaleGiocatori); 
                } while (giocatori.ElementAt(posGioc).Value == 1);
                giocatori[giocatori.ElementAt(posGioc).Key] = 1; 
            }
            stampaPunteggio(); 
            // Configurazione ed avvio thread gestori dei campi 
            for(int i=0; i<CORSIE; i++)
            {
                thArbCampo[i] = new Thread(gestisciCampo);
                thArbCampo[i].Name = (i + 1).ToString(); // 1, 2, 3, 4 
                thArbCampo[i].Start(); // 4 Thread avviati 
            }
            
            for (int i = 0; i < CORSIE; i++)
            {
                thArbCampo[i].Join();
                Console.WriteLine("FINE GESTORE CAMPO " + (i + 1).ToString()); 
            }
            // Calcolo del vincitore 
            setLabel(lblEsito, ""); 
            for(int i=0; i<puntiGiocatori.Length; i++)
            {
                if (puntiGiocatori[i] == puntiGiocatori.Max())
                    setLabel(lblEsito, lblEsito.Text +
                        Environment.NewLine +
                        giocatori.ElementAt(i).Key);
            }
        }

        private void gestisciCampo()
        {
            // 4 Thread eseguono le istruzioni successive 
            int posGioc;
            Label[] lblGioc;
            PictureBox picGioc;
            Control[] parametri = new Control[3]; 

            Thread.Sleep(100); 
            lock (lock_campo)
            {
                if (giocatoriResidui() > 0)
                {
                    do
                    {
                        posGioc = rnd.Next(0, totaleGiocatori); 
                    } while (giocatori.ElementAt(posGioc).Value != 1);
                    giocatori[giocatori.ElementAt(posGioc).Key] = 0;
                    thCampo[Convert.ToInt32(Thread.CurrentThread.Name) - 1] = new Thread(eseguiPartita);
                    lblGioc = new Label[2]; 
                    picGioc = new PictureBox();
                    lblGioc[0] = (Label)Controls["lblGioc" + (Thread.CurrentThread.Name)];
                    setLabel(lblGioc[0], giocatori.ElementAt(posGioc).Key);
                    Thread.Sleep(300);
                    lblGioc[1] = (Label)Controls["lblPunti" + (Thread.CurrentThread.Name)];
                    picGioc = (PictureBox)Controls["picB" + (Thread.CurrentThread.Name)];
                    parametri[0] = lblGioc[0]; // NomeGiocatore 
                    parametri[1] = lblGioc[1];  // Punti
                    parametri[2] = picGioc;

                    thCampo[Convert.ToInt32(Thread.CurrentThread.Name) - 1].Name = posGioc.ToString();
                    thCampo[Convert.ToInt32(Thread.CurrentThread.Name) - 1].Start(parametri); 
                }
            }// Accesso bloccato 
            thCampo[Convert.ToInt32(Thread.CurrentThread.Name) - 1].Join(); 
            // join 
            if (giocatoriResidui() > 0)
                gestisciCampo(); 
        }

        private void eseguiPartita(object par)
        {
            Label[] lbl = new Label[2]; 
            PictureBox pic = new PictureBox();
            int punteggio;
            int posGioc; 
            lbl[0] = (Label)(par as Control[])[0];
            lbl[1] = (Label)(par as Control[])[1]; 
            pic = (PictureBox)(par as Control[])[2];

            for(int i=0; i<TIRI; i++)
            {
                do
                {
                    setPos(pic, pic.Location.X - rnd.Next(10, 20), pic.Location.Y);
                    Thread.Sleep(rnd.Next(10, 50)); 
                } while (pic.Location.X >= PALLA_FINE_X);
                setPos(pic, PALLA_INIZIO_X, pic.Location.Y);
                /* Calcolo punteggio */
                punteggio = rnd.Next(0, 10);
                posGioc = Convert.ToInt32(Thread.CurrentThread.Name);
                puntiGiocatori[posGioc] += punteggio; 

                setLabel(lbl[1], "Punti: " + puntiGiocatori[posGioc].ToString());
            }
            stampaPunteggio();
        }

        private void setPos(PictureBox pic, int x, int y)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                pic.Location = new Point(x, y);
            });
        }

        private void setLabel(Label lbl, string msg)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                lbl.Text = msg;
            }); 
        }

        private int giocatoriResidui()
        {
            int giocRes = 0;
            for (int i = 0; i < giocatori.Count; i++) 
            {
                if (giocatori.ElementAt(i).Value == 1)
                    giocRes++; 
            }
            return giocRes; 
        }
        private void stampaPunteggio()
        {
            BeginInvoke((MethodInvoker)delegate () {
                txtPunteggio.Text = ""; 
                for(int i=0; i<giocatori.Count; i++)
                {
                    txtPunteggio.Text += "[" + giocatori.ElementAt(i).Value + "]" +
                                giocatori.ElementAt(i).Key + ": " + puntiGiocatori[i].ToString();
                    txtPunteggio.Text += Environment.NewLine; 
                }
            }); 
        }
    }
}
