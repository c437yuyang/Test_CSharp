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

namespace _26_socketClient
{
    public partial class FormClient : Form
    {

        private Socket _currentSocket;
        private Thread curentReceiveThread;

        public FormClient()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_currentSocket == null)
                _currentSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //currentSocket.Connect(IPAddress.Parse(tb_Ip.Text.Trim()), int.Parse(tb_port.Text));
                _currentSocket.Connect("127.0.0.1", 50000);
            }
            catch (System.Exception ex)
            {
                showMsg("连接到服务器失败，请检查网络连接!");
                return;
            }

            Thread th = new Thread(() =>
            {
                while (true)
                {

                    try
                    {
                        byte[] buffer = new byte[1024 * 1024];
                        int r = _currentSocket.Receive(buffer);
                        if (r <= 0)
                        {
                            showMsg("服务器退出！");
                            _currentSocket.Shutdown(SocketShutdown.Both);
                            _currentSocket.Close();
                            return;
                        }
                        showMsg("收到来自:" + _currentSocket.RemoteEndPoint.ToString() + "的消息：" + Encoding.Default.GetString(buffer, 0, r));
                    }
                    catch (System.Exception ex)
                    {
                        showMsg("服务器非正常退出！");
                        _currentSocket.Shutdown(SocketShutdown.Both);
                        _currentSocket.Close();
                        return;
                    }

                }
            });
            th.IsBackground = true;
            th.Start();
            curentReceiveThread = th;
        }


        private void showMsg(Object o)
        {

            if (tb_log.InvokeRequired)
            {
                while (!this.tb_log.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.tb_log.Disposing || this.tb_log.IsDisposed)
                        return;
                }
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

        private void btn_sendMsg_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.Default.GetBytes(tb_msg.Text.Trim());
            if (buffer.Length != 0)
            {
                if (_currentSocket != null && _currentSocket.Connected)
                    _currentSocket.Send(buffer);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (curentReceiveThread != null)
                curentReceiveThread.Abort();

            if (_currentSocket != null && _currentSocket.Connected)
            {
                _currentSocket.Shutdown(SocketShutdown.Both);
                _currentSocket.Close();


            }
        }

        private void btn_sendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            FileStream fs;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                NetworkStream ns = new NetworkStream(_currentSocket);
                fs = File.OpenRead(ofd.FileName);

                int size = 0;//初始化读取的流量为0   
                long len = 0;//初始化已经读取的流量 
                             //_fileName = _fileName.Replace("\\", "/");
                             //while (_fileName.IndexOf("/") > -1)
                             //{
                             //    _fileName = _fileName.Substring(_fileName.IndexOf("/") + 1);
                             //}
                             //_fileName = @"E:\" + _fileName;
                byte[] fileNameByte = Encoding.Unicode.GetBytes(ofd.FileName);
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                bool isfirst = true;
                while (len < fs.Length)
                {
                    byte[] buffer = new byte[512];
                    if (isfirst)
                    {
                        byte[] filebuf = new byte[400];
                        fileNameLen.CopyTo(filebuf, 0);
                        fileNameByte.CopyTo(filebuf, 4);
                        ns.Write(filebuf, 0, 400);
                        isfirst = false;
                        //updateProgress(0);
                    }
                    else
                    {
                        size = fs.Read(buffer, 0, buffer.Length);
                        ns.Write(buffer, 0, size);
                        len += size;
                        //updateProgress(Convert.ToInt32(len));
                    }
                }
                fs.Flush();
                ns.Flush();
                fs.Close();
                ns.Close();
                //updateProgress(progressBar1.Maximum);



            }


        }
    }
}
