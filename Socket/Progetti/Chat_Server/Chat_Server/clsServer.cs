using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Server
{

    // Definiamo firma della procedura di Evento datiRicevutiEvent
    public delegate void datiRicevutiEventHandler(string msg);
    // Definiamo firma della procedura di Evento erroreConnessioneEvent
    public delegate void erroreConnessioneEventHandler(string msg);
    // Definiamo firma della procedura di Evento statoConnessioneEvent
    public delegate void statoConnessioneEventHandler(string msg);
    class clsServer
    {
        private int _contClient = 0; //conteggio client collegati
        private int _contMsg = 0; //conteggio messaggi inviati da quando il server è stato attivato
        public event datiRicevutiEventHandler datiRicevutiEvent; //richiamo un evento che smisterà i pacchetti
        public event erroreConnessioneEventHandler erroreConnessioneEvent; //richiamo un evento che salverà i crash
        public event statoConnessioneEventHandler statoConnessioneEvent; //mostro l'errore
        public int portUDP = 27272; //porta per la trasmissione in UDP
        public int portTCP = 27271; //porta per la ricezione in TCP
        Socket sUDP; //socket per la trasmissione in UDP
        Socket sTCP; //socket per la ricezione in TCP
        Socket connID;
        const int MAX_BYTE = 20000;
        const int MAX_CONN = 200; // max connessione client accettati
        private volatile bool threadRun = true; //bool che gestisce l'utilizzo del socket
        private Thread threadAscolto; //thread per il socket di ascolto TCP

        public int contClient
        {
            //aggiunge/toglie un client e lo stampa
            get { return _contClient; }
            set { 
                _contClient = value;
                //changeNUtenti();
            }
        }
        public int contMsg
        {
            //aggiunge un msg e lo stampa
            get { return _contMsg; }
            set {
                _contMsg = value;
                //changeNMsg();
            }
        }

        //manca la lista degli utenti online
        public void sendUdp(object id, object ip)
        {
            //uso porta 27272
            string aus = ip.ToString(); //converto l'ip preso dalla cmb o del client a cui mandare un pacchetto
            int ide = Convert.ToInt32(id); //converto l'id
            switch (ide)
            {
                case 1:
                    trasmettiIP(ide + "<" + aus);
                    break;
                case 2:
                    trasmettiUtenti(ide + "<");
                    break;
            }
        }
        public void avvia()
        {
            if (threadAscolto == null)
            {
                // Instanzio un nuovo Thread 
                threadAscolto = new Thread(receiveTCP);
                // Avvio il Thread 
                threadAscolto.Start();
                // Aspetto finchè il Thread non è avviato  
                while (!(threadAscolto.IsAlive)) ;
            }
        }
        public void receiveTCP()
        {
            erroreConnessioneEvent += new erroreConnessioneEventHandler(visualizzaErrore); //aggiungo evento
            statoConnessioneEvent += new statoConnessioneEventHandler(visualizzaStato); //aggiungo evento
            datiRicevutiEvent += new datiRicevutiEventHandler(datiRicevuti); //aggiungo evento

            //uso porta 27271
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, portTCP); //istanzio un nuovo endpoint che riceve da in ogni ip (posso cambiare e scegliere solo uno)
            sTCP.Bind(ep); // Mettiamo Server in ascolto su porta specifica
            sTCP.Listen(MAX_CONN); // metto in ascolto al massimo 200 client
            int nBytesRicevuti = 0; //bit ricevuti
            string msg; //il msg ricevuto da splittare
            byte[] bufferRX; //buffer di ricezione
            bufferRX = new byte[MAX_BYTE];

            bool esci; 
            int tm;
            while (threadRun)
            {
                try
                {
                    // Il socket principale (sockID) non attende l'arrivo di messaggi 
                    // ma richieste di connessione. 
                    // Ogni volta che arriva una richiesta di connessione
                    // il server si clona con un nuovo thread restituendo dentro connID un socket DEDICATO
                    // alla gestione di quella connessione, mentre sockID continua a mettere in coda ulteriori connessioni
                    // finchè non chiudo connID la connessione col client resta attiva
                    if (connID == null)  //se null vuol dire sono alla prima connessione o il client precedente si è disconnesso
                    {
                        connID = sTCP.Accept(); //accetto la connesssione
                        statoConnessioneEvent("Connesso"); //stampo connesso
                    }

                    //nBytesRicevuti = connID.Receive(bufferRX, maxBYTE, 0);
                    //// Converte il Vettore di Byte BufferRx in una Stringa 
                    //msg = Encoding.ASCII.GetString(bufferRX, 0, nBytesRicevuti);

                    // ricevo byte fino a quando non ho <
                    esci = false;
                    msg = null;
                    while (!esci && connID.Connected)
                    {
                        tm = connID.ReceiveTimeout;
                        bufferRX = new byte[MAX_BYTE];
                        nBytesRicevuti = connID.Receive(bufferRX);
                        msg += Encoding.ASCII.GetString(bufferRX, 0, nBytesRicevuti);
                        if ((msg.IndexOf("<") > -1) || (nBytesRicevuti == 0))
                        {
                            esci = true;
                        }
                    }
                    if (nBytesRicevuti > 0)
                    {
                        //tolgo <
                        msg = msg.Substring(0, msg.Length - 5);
                        // Genero evento per Visualizzare i Dati ricevuti 
                        datiRicevutiEvent(msg);
                    }
                    else
                        chiudiConnessione();  //quando chiudo la connessione dal client mi va in loop e contunua a ricevere 0 byte
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode != 10004) //ignoro errore generato quando termino il thread
                    {
                        erroreConnessioneEvent(ex.Message);
                        //se ho un eccezione chiudo il socket attualmente aperto e ritorno in ascolto
                        chiudiConnessione();
                    }
                }
            }
        }

        private void trasmettiUtenti(string aus)
        {
            //trasmetto tutti gli utenti su una riga sola, separati dal |

            StreamReader sr = new StreamReader(@"C:\ChatMarello\users.txt");
            while (!sr.EndOfStream)
            {
                aus += sr.ReadLine();
                aus += "|";
            }
            sr.Close();

            IPAddress broadcast = IPAddress.Parse("192.168.1.255"); //192.168.1.255 a casa, 10.0.255.255 a scuola
            byte[] sendbuf = Encoding.ASCII.GetBytes(aus);
            IPEndPoint ep = new IPEndPoint(broadcast, portUDP);
            sUDP.SendTo(sendbuf, ep);
            MessageBox.Show(aus);
        }
        public bool trovaUserInFile(string nome)
        {
            //vado a cercare il nome, se è già presente cancello la riga
            bool aus3 = false; //trovato
            StreamReader sr = new StreamReader(@"C:\ChatMarello\users.txt"); //apro file user che contiene es: antonio;17.32.59
            string tempFile = Path.GetTempFileName(); //creo file temp
            StreamWriter sw = new StreamWriter(tempFile); //metto in scrittura il file temp
            while (!sr.EndOfStream)
            {
                string aus = sr.ReadLine(); //leggo l'utente
                string aus2 = aus.Split(';')[0]; //controllo solo il suo nome
                if(aus2 == nome)
                {
                    aus3 = true; //imposto trovato a true
                }
                else
                {
                    sw.WriteLine(aus); //altrimenti riscrivo la linea
                }
            }
            sr.Close();
            sw.Flush();
            sw.Close();
            File.Delete(@"C:\ChatMarello\users.txt");
            File.Move(tempFile, @"C:\ChatMarello\users.txt");
            if (aus3) return true;
            else return false;
            //successivamente si andrà a aggiungere l'utente
        }
        public string ottieniIPDalNome(string nome)
        {
            //vado a cercare l'indirizzo avendo il nome
            string aus3 = "";
            StreamReader sr = new StreamReader(@"C:\ChatMarello\users.txt"); //apro file user che contiene es: antonio;17.32.59
            while (!sr.EndOfStream)
            {
                string aus = sr.ReadLine(); //leggo l'utente
                string aus2 = aus.Split(';')[0]; //controllo solo il suo nome
                if (aus2 == nome)
                {
                    aus3 = aus.Split(';')[1]; //prendo il suo indirizzo
                }
            }
            sr.Close();
            return aus3;
            //successivamente si andrà a aggiungere l'utente
        }

        public void createSocket()
        {
            sUDP = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //istanzio il socket UDP
            sTCP = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //istanzio il socket TCP
        }
        public void trasmettiIP(string aus)
        {
            //trasmetto l'indirizzo ip del server in modo che tutti i client sappiano a chi connettersi
            
            IPAddress broadcast = IPAddress.Parse("192.168.1.255"); //192.168.1.255 a casa, 10.0.255.255 a scuola
            byte[] sendbuf = Encoding.ASCII.GetBytes(aus); 
            IPEndPoint ep = new IPEndPoint(broadcast, portUDP);
            sUDP.SendTo(sendbuf, ep);
            MessageBox.Show(aus);
        }
        public void scriviSuFileUser(string nome, string ip)
        {
            //funzione che aggiunge un nuovo utente nel file sia nuovo sia lo riscrive se mi ricollego
            StreamWriter sw;
            sw = new StreamWriter(@"C:\ChatMarello\users.txt", true);
            sw.WriteLine(nome + ";" + ip); //es: marco;192.168.0.1
            sw.Flush(); //svuoto buffer
            sw.Close();
        }
        public void scriviSuFileLog(int id, string sender, string receiver, string msg)
        {
            //funzione che aggiunge un msg nei log di una chat
            StreamWriter sw;
            DateTime val;
            val = DateTime.Now;
            sw = new StreamWriter(@"C:\ChatMarello\"+id.ToString() + ".txt", true);
            sw.WriteLine(sender +";" + receiver + ";" + msg + ";" + val.Hour + "." + val.Minute + "." + val.Second); //es: marco;antonio;ciao;17.32.59
            sw.Flush(); //svuoto buffer
            sw.Close();
        }
        private int cercaIDChat(string sender, string receiver)
        {
            //restituisce l'id di una chat 
            StreamReader sr = new StreamReader(@"C:\ChatMarello\chat.txt");
            string aus = "";
            string[] aus2 = new string[3];
            int id = -1;
            while (!sr.EndOfStream)
            {
                aus = sr.ReadLine();
                aus2 = aus.Split(';');
                if (aus2[0] == sender && aus2[1] == receiver)
                {
                    id = Convert.ToInt32(aus2[2]);
                }
            }
            if (id == -1)
            {
                aggiungiIDChat(sender, receiver);
                id = cercaIDChat(sender, receiver);
            }
            sr.Close();
            return id;
        }
        public void aggiungiIDChat(string sender, string receiver)
        {
            //funzione che aggiunge un id chat e crea 
            int id = getNumeroID();
            id += 1;
            StreamWriter sw;
            sw = new StreamWriter(@"C:\ChatMarello\" + id.ToString() + ".txt", true);
            sw = new StreamWriter(@"C:\ChatMarello\chat.txt", true);
            sw.WriteLine(sender + ";" + receiver + ";" + id); //es: marco;antonio;2
            sw.WriteLine(receiver + ";" + sender + ";" + id); //es: antonio;marco;2
            sw.Flush(); //svuoto buffer
            sw.Close();
        }

        private int getNumeroID()
        {
            //metodo che ottiene il numero delle chat contando le righe e dividendo per due in quanto si ripetono 
            StreamReader sr = new StreamReader(@"C:\ChatMarello\chat.text");
            int cont = 0;
            while (!sr.EndOfStream)
            {
                cont++;
            }
            sr.Close();
            return cont/2;
        }
        public void chiudiConnessione()
        {
            try
            {
                //chiudo la connessione con il client,.
                //così adesso vengono serviti eventuali altri client in coda
                connID.Shutdown(SocketShutdown.Both);
                connID.Close();
                connID = null;
                statoConnessioneEvent("Disconnesso");
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }
        public void invia(string msg)
        {
            try
            {
                byte[] bufferTX;
                // Serializzo la Stringa ricevuta 
                bufferTX = Encoding.ASCII.GetBytes(msg);
                // Invio la Stringa ricevuta all' endPoint 
                connID.Send(bufferTX, bufferTX.Length, 0);
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }
        public void termina()
        {
            // Chiudo il Socket 
            sTCP.Close();
            // Arresto il Thread 
            threadRun = false;
            //if (threadAscolta != null)
            //    try
            //    {
            //        threadAscolta.Abort();
            //    }
            //    catch (Exception ex)
            //    { }
        }
        private void visualizzaStato(string msg)
        {
            Console.WriteLine("ERRORE STATO: " + msg);
        }
        private void visualizzaErrore(string msg)
        {
            scriviLogCrash(msg);
        }
        private void datiRicevuti(string msg)
        {
            MessageBox.Show(msg);
            // Server Risponde al Client
            invia("ACK");
            int id = Convert.ToInt32(msg.Split('<')[0]);

            switch (id)
            {
                //id 4 --> ricevo un messaggio e lo salvo
                //id 5 --> carico un username nella lista di quelli attivi
                case 4:
                    msgRicevuto(msg);
                    break;
                case 5:
                    usernameRicevuto(msg);
                    break;
                case 6:
                    scollegamentoRicevuto(msg);
                    break;

            }
            // Test Coda Client 

        }

        private void scollegamentoRicevuto(string msg)
        {
            //utenti connessi --
            //msg composto da id<sender
        }

        private void usernameRicevuto(string msg)
        {
            //scrivo e utenti connessi ++
            //msg composto da id<sender<indirizzoip
            //aggiungo alla lista utenti collegati
            if (trovaUserInFile(msg.Split('<')[1]))
            {
                //cerco nella lista il suo nome e lo cancello
            }
            scriviSuFileUser(msg.Split('<')[1], msg.Split('<')[2]);
            //aggiungo alla lista
        }

        private void msgRicevuto(string msg)
        {
            //salvo e poi lo mando
            //msg composto da id<sender<receiver<msg
            int id = cercaIDChat(msg.Split('<')[1], msg.Split('<')[2]);
            scriviSuFileLog(id, msg.Split('<')[1], msg.Split('<')[2], msg.Split('<')[3]);
            mandaMsg(id, msg.Split('<')[1], msg.Split('<')[2], msg.Split('<')[3]);
        }

        private void scriviLogCrash(string msg)
        {
            //funzione che aggiunge un msg nei log di crash
            StreamWriter sw;
            DateTime val;
            val = DateTime.Now;
            sw = new StreamWriter(@"C:\ChatMarello\crashlog.txt", true);
            sw.WriteLine("[" + val.Hour + "." + val.Minute + "." + val.Second + "]" + " - " + msg); //es: marco;antonio;ciao;17.32.59
            sw.Flush(); //svuoto buffer
            sw.Close();
        }
        private void mandaMsg(int id, string sender, string receiver, string msg)
        {
            //cerco l'ip del del receiver
            string ipRec = ottieniIPDalNome(receiver); //ottengo l'ip avendo il nome
            //msg mandati ++
            string aus = 0 + '<' + sender + '<' + receiver + '<' + msg;
            IPAddress rec = IPAddress.Parse(ipRec); 
            byte[] sendbuf = Encoding.ASCII.GetBytes(aus);
            IPEndPoint ep = new IPEndPoint(rec, portUDP);
            sUDP.SendTo(sendbuf, ep);
        }
    }
}
