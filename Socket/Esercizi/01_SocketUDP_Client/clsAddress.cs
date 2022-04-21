using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _01_SocketUDP_Client
{
    public class clsAddress
    {
        public static List<IPAddress> ipList;

        static clsAddress()
        {
            ipList = new List<IPAddress>();
        }
        public static void findIP()
        {
            IPHostEntry hostInfo; // Lo usiamo per recuperare le informazioni dell'HOST
            // Aggiungo l'indirizzo localhost/broadcast --> 127.0.0.1
            ipList.Add(IPAddress.Parse("127.0.0.1"));
            hostInfo = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in hostInfo.AddressList)
            {
               // Analizzo indirizzo ip e prendo solo l'IPV4, scartando l'IPV6
               if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipList.Add(ip);
                }
            }
        }
    }
}
