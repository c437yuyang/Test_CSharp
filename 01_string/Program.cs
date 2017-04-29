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


            Console.ReadKey();
        }
    }
}
