using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _02_SocketTCP_Client
{
    public delegate void erroreConnessioneEventHandler(string msg);
    public class clsTCPClient
    {
        const int MAX_BYTE = 1024;
        private Socket socketID; // Socket Principale
        private EndPoint endPoint; // endPoint(ip, port) associato al server
        public event erroreConnessioneEventHandler erroreConnessioneEvent;
        public clsTCPClient(IPAddress ip, int porta)
        {
            socketID = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socketID.SendTimeout = 10000;

            socketID.ReceiveTimeout = 10000;

            endPoint = new IPEndPoint(ip, porta);
        }
        public void connetti()
        {
            try
            {
                socketID.Connect(endPoint);
            }
            catch (SocketException ex)
            {

                erroreConnessioneEvent(ex.Message);
            }
        }
        public void disconnetti()
        {
            try
            {
                socketID.Shutdown(SocketShutdown.Both);
                socketID.Close();
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
                byte[] bufferTx;
                msg += "<EQF>";
                // Serializzo
                bufferTx = Encoding.UTF8.GetBytes(msg);
                // Invio
                socketID.Send(bufferTx, bufferTx.Length, SocketFlags.None);
            }
            catch (SocketException ex)
            {

                erroreConnessioneEvent(ex.Message);
            }
        }
        public clsMessage ricevi()
        {
            int nBytesRicevuti;
            string msg;
            byte[] bufferRx;

            try
            { 
                // Istanza
                bufferRx = new byte[MAX_BYTE];
                // Ricezione
                nBytesRicevuti = socketID.Receive(bufferRx, MAX_BYTE, SocketFlags.None);
                // Deserializzo
                msg = Encoding.UTF8.GetString(bufferRx);
            }
            catch (SocketException ex)
            {

                erroreConnessioneEvent(ex.Message);
                msg = "";
            }
            return messaggio(msg);
        }
        private clsMessage messaggio(string msg)
        {
            string[] endP = endPoint.ToString().Split(':');
            clsMessage clsMsg = new clsMessage();
            clsMsg.Ip = endP[0];
            clsMsg.Port = endP[1];
            clsMsg.Messaggio = endP[2];

            return clsMsg;

        }
    }
}
