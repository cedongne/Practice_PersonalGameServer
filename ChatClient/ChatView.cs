using ChatClient.ClientSocket.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ChatView : Form
    {
        public ChatView()
        {
            InitializeComponent();
        }

        private void ClickBtnSendMessage(object sender, EventArgs e)
        {
        }

        private void ClickBtnCloseProgram(object sender, EventArgs e)
        {
            NetworkManager.Instance.Disconnect();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TextChangedTextBoxInputMessage(object sender, EventArgs e)
        {

        }
    }
}
