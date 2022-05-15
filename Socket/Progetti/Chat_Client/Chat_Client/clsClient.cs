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
        private const int porta = 11000; //porta per la trasmissione del server
        public static string cercaServer()
        {
            //funzione che si occupa di trovare l'indirizzo IP del server che viene trasmesso in broadcast, inizia con 1<EQC>

            UdpClient listener = new UdpClient(porta); //creo un nuovo client
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, porta); //creo un endpoint con qualsiasi indirizzo (per ricevere il broadcast)
            string aus = ""; //aus
            try
            {
                    byte[] bytes = listener.Receive(ref groupEP); //vado a salvarmi ciò che ricevo
                    aus = Encoding.ASCII.GetString(bytes, 0, bytes.Length); //convertito in stringa
                    //System.Windows.Forms.MessageBox.Show(aus); 
            }
            catch (SocketException e)
            {
                Console.WriteLine(e); //stampo l'errore
            }
            finally
            {
                listener.Close(); //chiudo il socket
            }
            return aus; //ritorno il messaggio ricevuto
        }
    }
}
