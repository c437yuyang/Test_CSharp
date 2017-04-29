using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_形参类型
{
    class Program
    {
        static void Main(string[] args)
        {

            #region
            //可变参数可以不传，传一个，传数组
            func();
            string s1 = "aaa";
            func(s1);
            string[] s2 = new string[]
            {
                "aaa",
                "aa1",
                "aa2",
                "aa3"
            };
            func(s2);
            #endregion
            Console.Read();
        }

        static void func(params string[] args)
        {
            foreach(string param in args)
            {
                Console.WriteLine(param);
            }
            Console.WriteLine("输出完毕");
        }
    }
}
