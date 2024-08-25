using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ChatClient.ClientSocket.Protocol
{
    public class NetworkManager
    {
        private static NetworkManager _instance = new NetworkManager();
        public static NetworkManager Instance { get { return _instance; } }

        private IPEndPoint _serverIPEP;

        private Socket _clientSocket;

        private NetworkManager()
        {
            _serverIPEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

        }

        public Boolean TryConnect()
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _clientSocket.BeginConnect(_serverIPEP, _ => { }, null);

            if(_clientSocket.Connected == false)
            {
                var connectFailMsgBoxOepration = MessageBox.Show(
                    "서버 연결에 실패했습니다. 다시 연결을 시도하시겠습니까?", 
                    "서버 연결 실패", 
                    MessageBoxButtons.YesNo);

                if (connectFailMsgBoxOepration.Equals(DialogResult.OK))
                {
                    TryConnect();
                }
                else
                {
                    Application.Exit();
                }

                return false;
            }

            return true;
        }

        public void Disconnect()
        {
            _clientSocket.Close();
        }
    }
}
