using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_01_NamedPipeServer
{
    class Program
    {
        static void Main(string[] args)
        {

            using (NamedPipeServerStream serverStream = new NamedPipeServerStream("testpipe"))
            {
                //等待连接
                serverStream.WaitForConnection();
                using (StreamWriter writer = new StreamWriter(serverStream))
                {
                    writer.AutoFlush = true;
                    string temp;
                    while ((temp = Console.ReadLine()) != "stop")
                    {
                        writer.WriteLine(temp);
                    }
                }
            }

        }
    }
}
