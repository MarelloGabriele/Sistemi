using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _01_SocketUDP_Client
{
    public class clsUDPClient
    {
        const int MAX_BYTES = 1024;
        private Socket socketID;
        private EndPoint endPointServer;

        public clsUDPClient(IPAddress ipServer, int portServer)
        {
            socketID = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            endPointServer = new IPEndPoint(ipServer, portServer);
        }
        public void invia(clsMessage clsMsg)
        {
            string messaggio = clsMsg.toCSV(';');
            byte[] bufferTx;

            bufferTx = Encoding.ASCII.GetBytes(messaggio);

            socketID.SendTo(bufferTx, bufferTx.Length, SocketFlags.None, endPointServer);
        }
    }
}
