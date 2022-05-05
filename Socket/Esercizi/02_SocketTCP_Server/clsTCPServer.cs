using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_SocketTCP_Server
{
    // Definiamo firma della procedura di Evento datiRicevutiEvent
    public delegate void datiRicevutiHandler(clsMessage msg);
    // Definiamo firma della procedura di Evento erroreConnessione
    public delegate void erroreConnessioneEventHandler(string msg);
    // Definiamo firma della procedura di Evento statoConnessioneEvent
    public delegate void statoConnessioneEventHandler(string msg);
    class clsTCPServer
    {
        const int MAX_BYTE = 1024; // lunghezza max buffer
        const int MAX_CONN = 20; // max connessioni client accettati
        private Socket socketID;
        private EndPoint endPoint; // socket (ip pora) associato al server
        private Thread threadAscolto;
        private volatile bool threadRun = true;
        private Socket connID;

        

        // Definiamo puntatori agli eventi
        public event datiRicevutiHandler datiRicevutiEvent;
        public event erroreConnessioneEventHandler erroreConnessioneEvent;
        public event statoConnessioneEventHandler statoConnessioneEvent;


        public clsTCPServer(IPAddress ip, int port)
        {
            socketID = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(ip, port);
            
            socketID.SendTimeout = 10000; // Impostazione timeout per il tempo di Invio
            socketID.ReceiveTimeout = 10000; // Impostazione timeout per il tempo di Ricezione

            socketID.Bind(endPoint);  // Mettiamo il server in ascolto su una porta specifica

            socketID.Listen(MAX_CONN); // Max lunghezza coda connessioni accettate prima di restituire "Server occupato"
        }

        public void avvia()
        {
            if (threadAscolto == null)
            {
                threadAscolto = new Thread(new ThreadStart(ricevi));
                threadAscolto.Start();
                while (!threadAscolto.IsAlive) ;
            }
        }
        private void ricevi()
        {
            byte[] bufferRx = new byte[MAX_BYTE];
            string msg;
            int nBytesRicevuti = 0;
            bool esci;

            while (threadRun)
            {
                try
                {
                    if(connID == null)
                    {
                        connID = socketID.Accept();
                        statoConnessioneEvent("Connesso");
                    }
                    esci = false;
                    msg = null;
                    while (!esci && connID.Connected)
                    {
                        bufferRx = new byte[MAX_BYTE];
                        msg += Encoding.UTF8.GetString(bufferRx,0, nBytesRicevuti);
                        if ((msg.IndexOf("<EQF>") > -1) || (nBytesRicevuti == 0))
                        {
                            esci = true;
                        }
                    }
                    if (nBytesRicevuti > 0)
                    {
                        msg = msg.Substring(0, msg.Length - 5);
                        datiRicevutiEvent(messaggio(msg));
                    }
                    else
                    {
                        chiudiConnessione();
                    }

                }
                catch (SocketException ex)
                {
                    erroreConnessioneEvent(ex.Message);
                    chiudiConnessione();
                }
            }
        }

        private clsMessage messaggio(string msg)
        {
            clsMessage clsMsg = new clsMessage();
            clsMsg.Ip = ((IPEndPoint)connID.RemoteEndPoint).Address.ToString();
            clsMsg.Port = ((IPEndPoint)connID.RemoteEndPoint).Port.ToString();
            clsMsg.Messaggio = msg;
            return clsMsg;
        }

        public void invia(string msg)
        {
            try
            {
                byte[] bufferTx;
                bufferTx = Encoding.UTF8.GetBytes(msg);
                connID.Send(bufferTx, bufferTx.Length, SocketFlags.None);
            }
            catch (SocketException ex)
            {

                erroreConnessioneEvent(ex.Message);
            }
        }
        public void chiudiConnessione()
        {
            try
            {
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
        public void chiudi()
        {
            threadRun = false;
            socketID.Close();
        }

    }
}
