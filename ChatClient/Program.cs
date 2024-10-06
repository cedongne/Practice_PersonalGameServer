using ChatClient.ClientSocket.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (NetworkManager.Instance.TryConnect() == false) {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NetworkManager.Instance.ChatView = new ChatView();
            NetworkManager.Instance.Start();
            Application.Run(NetworkManager.Instance.ChatView);
        }
    }
}
