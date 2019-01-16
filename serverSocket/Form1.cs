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
            /*
            try
            {
                //string hostname = Dns.GetHostName();
                //IPAddress serverIP = Dns.Resolve(hostname).AddressList[0];


                //Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //IPAddress serverIP = IPAddress.Parse("127.0.0.1");
                //IPAddress serverIP = Dns.Resolve("localhost").AddressList[0];


                //IPEndPoint serverhost = new IPEndPoint(serverIP, 80);
                //TcpListener tcpListener = new TcpListener(serverIP, 80);

                //serverSocket.Bind(serverhost);

                //serverSocket.Listen(int backlog);
                //serverSocket.Listen(10);    //其中參數 backlog 設定伺服端最大用戶連線數，可設定為 int.MaxValue 




                //指定伺服端 IP Address 與通訊埠
                IPAddress serverIP = IPAddress.Parse("127.0.0.1");
                //IPAddress serverIP = Dns.Resolve("localhost").AddressList[0];

                //建立伺服端 TcpListener
                TcpListener tcpListener = new TcpListener(serverIP, 80);

                //等候用戶連線
                tcpListener.Start();

            }
            catch (SocketException ex)
            {

            }
            */


            try
            {
                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress serverIP = IPAddress.Parse("127.0.0.1");

                IPEndPoint serverhost = new IPEndPoint(serverIP, 80);

                serverSocket.Bind(serverhost);

                serverSocket.Listen(10);

                while (true)
                {
                    try
                    {
                        //處理用戶端連線
                        Socket clientSocket = serverSocket.Accept();

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
