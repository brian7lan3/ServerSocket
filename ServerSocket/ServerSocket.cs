using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerSocket
{
    class ServerSocket
    {
        // 應用程式的主進入點
        static void Main(string[] args)
        {
            try
            {
                // 建立伺服端 Socketet
                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // 取得本機的識別名稱
                string hostname = Dns.GetHostName();

                // 取得主機的 DNS 資訊
                IPAddress serverIP = Dns.Resolve(hostname).AddressList[0];

                // Port = 80
                string Port = "80";

                // 處理主機 IP 位址及主機服務所需的通訊埠資訊
                IPEndPoint serverhost = new IPEndPoint(serverIP, Int32.Parse(Port));

                // 繫結設定伺服端 Socket
                serverSocket.Bind(serverhost);

                // 開始接聽等候用戶端的網路連接請求
                // 設定伺服端最大用戶端連線數為 int.MaxValue
                serverSocket.Listen(int.MaxValue);

                Console.WriteLine("Server started at: " + serverIP.ToString() + ":" + Port);

                ListenClient lc = new ListenClient(serverSocket);

                // 執行緒
                ThreadStart serverThreadStart = new ThreadStart(lc.ServerThreadProc);

                Thread serverthread = new Thread(serverThreadStart);

                serverthread.Start();
            }
            catch (Exception ex) { }
            finally { }
        }
    }
}
