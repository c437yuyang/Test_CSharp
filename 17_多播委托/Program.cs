using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_多播委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> ac1 = new Action<string>(M1);
            ac1 += M2;
            ac1 += M3;
            ac1 += M4;
            ac1 += M5;
            ac1 -= M2;
            ac1("王鹏"); //注意顺序不一定保证

            Action<string> ac2 = new Action<string>(M1);
            

            Console.Read();
        }

        static void M1(string msg)
        {
            Console.WriteLine(msg + "1");
        }
        static void M2(string msg)
        {
            Console.WriteLine(msg + "2");
        }
        static void M3(string msg)
        {
            Console.WriteLine(msg + "3");
        }
        static void M4(string msg)
        {
            Console.WriteLine(msg + "4");
        }
        static void M5(string msg)
        {
            Console.WriteLine(msg + "5");
        }
    }
}
