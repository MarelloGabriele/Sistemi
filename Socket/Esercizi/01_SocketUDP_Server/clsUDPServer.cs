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
    public class clsUDPServer
    {
        private const int MAX_BYTES = 1024;
        private Socket socketID; // Socket principale del nostro server 
        private EndPoint endPointServer;
        private EndPoint endPointClient;
        private Thread threadAscolto; // Thread in ascolto su porta
        private volatile bool threadRun = true;

        public clsUDPServer(IPAddress ip, int port)
        {
            socketID = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
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
                while (!threadAscolto.IsAlive) ;
            }
        }

        private void ricevi()
        {
            
        }
        public void chiudi()
        {
            threadRun = false;
            socketID.Close();
        }
    }
}
