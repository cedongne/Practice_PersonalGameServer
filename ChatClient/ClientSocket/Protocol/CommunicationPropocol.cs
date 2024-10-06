using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ChatClient.ClientSocket.Protocol
{
    public partial class NetworkManager
    {
        public class ChatClient
        {
            public Socket ClientSocket { get; }
            public NetworkStream NetworkStream { get; }
            public StreamReader Reader { get; }
            public StreamWriter Writer { get; }

            public ChatClient(Socket clientSocket)
            {
                ClientSocket = clientSocket;
                NetworkStream = new NetworkStream(clientSocket);
                Reader = new StreamReader(NetworkStream, Encoding.GetEncoding("utf-8"));
                Writer = new StreamWriter(NetworkStream, Encoding.GetEncoding("utf-8")) { AutoFlush = true };
            }
        }

        public void SendMessage(String message)
        {
            Client.Writer.WriteLine(message);

//            _clientSocket.Send(Encoding.Default.GetBytes(message));
        }

        public void ReceiveMessage()
        {
            String message;

            while (Client.ClientSocket.Connected)
            {
                try
                {
                    message = Client.Reader.ReadLine();

                    ChatView.GetChatBox.AppendText(message);
                }
                catch (Exception ex)
                {
                    if (_clientSocket.Connected == false)
                    {
                    }

                    break;
                };
            }
        }
    }
}
