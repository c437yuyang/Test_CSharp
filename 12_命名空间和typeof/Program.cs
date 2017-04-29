using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
using alias = test;

namespace _12_命名空间和typeof
{
    class Program
    {
        static void Main(string[] args)
        {
            const string s1 = "a";
            int i = 0;
            string s = "a";
            Console.WriteLine(s.GetType());
            Console.WriteLine(i.GetType());

            //clsA.sayHi();
            alias::clsA.sayHi(); //两种方式都可以
            alias.clsA.sayHi();
            clsA a = new clsA();
            Console.WriteLine(a.GetType().Namespace);
            Console.Read();
        }
    }
}

namespace test
{
    class clsA
    {
        public static void sayHi()
        {
            Console.WriteLine("hi");
        }
    }
}