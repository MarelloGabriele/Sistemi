using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _02_SocketTCP_Server
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
        public static IPAddress findIP(string host)
        {
            IPAddress ip = null;
            IPHostEntry hostInfo;
            // Verifico se l'host è un indirizzo valido
            if(!(IPAddress.TryParse(host,out ip)))
            {
                hostInfo = Dns.GetHostEntry(host);
                foreach(IPAddress ip1 in hostInfo.AddressList)
                {
                    if(ip1.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ip = ip1;
                    }
                }
            }
            return ip;
        }
    }
}
