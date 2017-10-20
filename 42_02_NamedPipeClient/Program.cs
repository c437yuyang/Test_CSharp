using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_02_NamedPipeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NamedPipeClientStream clientStream = new NamedPipeClientStream("testpipe"))
            {
                //开启连接
                clientStream.Connect();
                using (StreamReader reader = new StreamReader(clientStream))
                {
                    string temp;
                    while ((temp = reader.ReadLine()) != "stop")
                    {
                        Console.WriteLine("{0}:{1}", DateTime.Now, temp);
                    }
                }
            }
        }
    }
}
