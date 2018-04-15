using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_string
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            list.Add("aaaa");
            list.Add("vvv");
            list.Add("ccccc");

            
            Console.WriteLine(string.Join(" and ", list));

            Console.WriteLine("aaa"=="aaa");
            string str = "aaa";
            string str1 = "aaa";
            Console.WriteLine(str==str1); //True ,这里面string可以想象成是值类型

            string str2 = new string('a',3);
            Console.WriteLine(str == str2); //True ,这里面string可以想象成是值类型


            Console.ReadKey();
        }
    }
}
