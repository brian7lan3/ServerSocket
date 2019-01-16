using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace serverSocket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress serverIP = IPAddress.Parse("127.0.0.1");

#pragma warning disable CS0618 // 類型或成員已經過時
                //IPAddress serverIP = Dns.Resolve("localhost").AddressList[0];
#pragma warning restore CS0618 // 類型或成員已經過時


                IPEndPoint serverhost = new IPEndPoint(serverIP, 80);

                serverSocket.Bind(serverhost);

                //serverSocket.Listen(int backlog);
                serverSocket.Listen(10);    //其中參數 backlog 設定伺服端最大用戶連線數，可設定為 int.MaxValue 
            }
            catch (SocketException ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
