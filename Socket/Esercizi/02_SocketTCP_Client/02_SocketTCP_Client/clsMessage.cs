using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SocketTCP_Client
{
   
    public class clsMessage
    {
        private string _ip;
        private string _port;
        private string _messaggio;

        public clsMessage(string _ip = "", string _port = "", string _msg = "")
        {
            this._ip = _ip;
            this._port = _port;
            this._messaggio = _msg;
        }
        public clsMessage(string csv, char separatore = ';')
        {
            fromCSV(csv, separatore);
        }
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
        public string Messaggio
        {
            get { return _messaggio; }
            set { _messaggio = value; }
        }

        private void fromCSV(string csv, char separatore)
        {
            string[] param = csv.Split(separatore);
            this._ip = param[0];
            this._port = param[1];
            this._messaggio = param[2];
        }
        public string toCSV(char separatore = ';')
        {
            return _ip + separatore + _port + separatore + _messaggio;
        }
        public string[] toArray()
        {
            return new string[] { _ip, _port, _messaggio};
        }
    }
}
