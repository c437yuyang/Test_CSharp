using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25_socketServer
{
    public partial class FormServer : Form
    {
        private Socket _socketListen;
        private List<Socket> _listSocket = new List<Socket>();
        public FormServer()
        {
            InitializeComponent();
        }

        private void showMsg(Object o)
        {

            if (tb_log.InvokeRequired)
            {
                tb_log.Invoke(new Action<string>((s) =>
                {
                    tb_log.Text += s; //这里可以直接写成s,也不用as string
                    tb_log.Text += "\r\n";
                }), o);
            }
            else
            {
                tb_log.Text += o as string;
                tb_log.Text += "\r\n";
            }
        }

        private void btnStartListen_Click(object sender, EventArgs e)
        {
            //1.三个参数:寻址方式，传输数据方式，通信协议
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipAddr = IPAddress.Parse(tb_Ip.Text);
            IPEndPoint ipEndPt = new IPEndPoint(ipAddr, int.Parse(tb_port.Text));
            socket.Bind(ipEndPt);

            //启动线程开始监听
            socket.Listen(10);
            showMsg("开始监听...");
            _socketListen = socket;

            Thread th = new Thread((s) =>
            {

                Socket serverSocket = s as Socket;
                while (true)
                {
                    //等待客户端连接，会阻塞主线程，因此单独起一个线程
                    //连上之后自动生成新的socket,监听的socket只负责监听，因此返回一个新的socket用于通信
                    Socket proxSocket = serverSocket.Accept(); //打印出来是80但是不一定是。。有争议
                    showMsg("有一个客户端连上:" + proxSocket.RemoteEndPoint.ToString());
                    _listSocket.Add(proxSocket);
                    proxSocket.Send(Encoding.Default.GetBytes("欢迎连接"));

                    //接收消息
                    //proxSocket.Receive(); //也会阻塞线程，直到对应客户端发来消息才会继续执行，所以另起线程
                    new Thread(p =>
                    {
                        Socket pSocket = p as Socket;
                        while (true)
                        {
                            try
                            {
                                int size = 0;
                                int len = 0;
                                using(NetworkStream ns = new NetworkStream(pSocket))
                                {
                                    byte[] file = new byte[400];
                                    ns.Read(file, 0, 4);
                                    int filenamelen = BitConverter.ToInt32(file, 0);
                                    ns.Read(file, 4, filenamelen);
                                    string fileName = Encoding.Unicode.GetString(file, 4, filenamelen);
                                    FileInfo f = new FileInfo(fileName);
                                    Directory.CreateDirectory(f.DirectoryName);
                                    fileName = "E:\\" + f.Name;
                                    using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                                    {
                                        bool isfirst = true;
                                        byte[] buffer = new byte[512];

                                        while ((size = ns.Read(buffer, 0, buffer.Length)) > 0)
                                        {
                                            if (isfirst)
                                            {
                                                fs.Write(buffer, 400 - filenamelen - 4, size - 400 + filenamelen + 4);
                                                len += size;
                                                isfirst = false;
                                            }
                                            else
                                            {
                                                fs.Write(buffer, 0, size);
                                                len += size;
                                                Console.WriteLine("单次长度:" + size);
                                                Console.WriteLine("总长du:" + len);
                                            }
                                        }
                                        Console.WriteLine("接收完毕!");
                                    }
                                        

                                }

                                //byte[] buffer = new byte[1024 * 1024];
                                //int r = pSocket.Receive(buffer);
                                //if (r == 0)
                                //{
                                //    showMsg("客户端" + pSocket.RemoteEndPoint.ToString() + "退出.");
                                //    pSocket.Shutdown(SocketShutdown.Both);
                                //    pSocket.Close();
                                //    listSocket.Remove(pSocket);
                                //    return; //跳出此方法，也就结束了while，结束了线程
                                //}
                                //string msg = Encoding.Default.GetString(buffer, 0, r);
                                //showMsg("收到来自" + pSocket.RemoteEndPoint.ToString() + "的消息:" + msg);
                            }
                            catch (System.Exception ex)
                            {
                                showMsg("客户端" + pSocket.RemoteEndPoint.ToString() + "异常退出.");
                                pSocket.Shutdown(SocketShutdown.Both);
                                pSocket.Close();
                                _listSocket.Remove(pSocket);
                                return; //跳出此方法，也就结束了while，结束了线程
                            }
                        }
                    })
                    { IsBackground = true }.Start(proxSocket);
                }
            });
            th.IsBackground = true;
            th.Start(_socketListen);
        }

        private void btn_sendMsg_Click(object sender, EventArgs e)
        {
            string msg = tb_msg.Text.Trim();
            byte[] buffer = Encoding.Default.GetBytes(msg);
            foreach (var item in _listSocket)
            {
                if (item != null && item.Connected)
                    item.Send(buffer);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_socketListen != null)
                {
                    _socketListen.Shutdown(SocketShutdown.Both);
                    _socketListen.Close();
                }
            }
            catch
            {
                return;
            }

        }

        private void btn_sendFile_Click(object sender, EventArgs e)
        {

        }
    }
}
