using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    public class clsClient
    {
        private const int porta = 11000;
        public static string cercaServer()
        {
            //funzione che si occupa di trovare l'indirizzo IP del server che viene trasmesso in broadcast, inizia con 1<EQC>

            UdpClient listener = new UdpClient(porta);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, porta);
            string aus = "";

            try
            {
                    byte[] bytes = listener.Receive(ref groupEP);
                    aus = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    System.Windows.Forms.MessageBox.Show(aus);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
            return aus;
        }
    }
}
