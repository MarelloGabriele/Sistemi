using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_SocketUDP_Server
{
    public delegate void datiRicevutiEventHandler(clsMessage messaggio); 
    public class clsUDPServer
    {
        private const int MAX_BYTES = 1024;
        private Socket socketID; // Socket principale del nostro server
        private EndPoint endPointServer;
        private EndPoint endPointClient;
        private Thread threadAscolto; // Thread in ascolto su porta 
        private volatile bool threadRun = true; 

        public event datiRicevutiEventHandler datiRicevutiEvent;
        public clsUDPServer(IPAddress ip, int port)
        {
            socketID = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Dgram, ProtocolType.Udp);
            endPointServer = new IPEndPoint(ip, port);
            // 
            socketID.Bind(endPointServer);
        }
        public void avvia()
        {
            if(threadAscolto == null)
            {
                threadAscolto = new Thread(new ThreadStart(ricevi)); 
                threadAscolto.Start();
                while (!threadAscolto.IsAlive);
            }
        }

        private void ricevi()
        {
            int nBytesRicevuti;
            string msg;
            byte[] bufferRx;
            clsMessage clsMes; 

            bufferRx = new byte[MAX_BYTES];
            endPointClient = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
            while (threadRun)
            {
                try
                {
                    nBytesRicevuti = socketID.ReceiveFrom(bufferRx, MAX_BYTES, SocketFlags.None, ref endPointClient);
                    msg = Encoding.ASCII.GetString(bufferRx);
                    clsMes = new clsMessage(msg, ';');

                    clsMes.Ip = (endPointClient as IPEndPoint).Address.ToString();
                    clsMes.Port = (endPointClient as IPEndPoint).Port.ToString();

                    datiRicevutiEvent(clsMes); 
                }
                catch(SocketException ex)
                {
                    Console.WriteLine(ex.ErrorCode + ": " + ex.Message); 
                }
            }
        }
        public void chiudi()
        {
            threadRun = false;
            socketID.Close();
        }
    }
}
