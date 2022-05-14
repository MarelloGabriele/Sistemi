using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Server
{
    class clsServer
    {
        public static void trasmettiIndirizzoServer(string ip)
        {
            //trasmetto l'indirizzo ip del server in modo che tutti i client sappiano a chi connettersi
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("serverIp:10.0.255.255");
            byte[] sendbuf = Encoding.ASCII.GetBytes(ip);
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);
            s.SendTo(sendbuf, ep);
            Console.WriteLine("Message sent to the broadcast address");
        }
    }
}
