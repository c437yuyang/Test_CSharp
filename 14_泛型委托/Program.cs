using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_泛型委托
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 泛型委托
            //无参数无返回值的委托
            Action ac1 = new Action(m1);
            ac1();

            //自定义的泛型委托
            MyGenericDelegate<string> MGD = new MyGenericDelegate<string>(getLen);
            Console.WriteLine(MGD("aaaa"));

            //系统提供的泛型委托
            // action都是无返回值的委托
            Action<string> ac2 = new Action<string>(sayHi);
            ac2("abcde");

            //func,最后一个类型就是返回值的类型
            Func<int, int, int, int> fun = M2;
            Console.WriteLine(M2(1, 2, 3));

            //lambda版本
            Func<string,int> f = (str) => { return str.Length; };
            int x = f("aaa");
            Console.WriteLine(x);
            #endregion
            Console.Read();


        }

        static void m1()
        {
            Console.WriteLine("aa");
        }

        static int M2(int n1,int n2,int n3)
        {
            return n1 + n2 + n3;
        }


        static int getLen(string str)
        {
            return str.Length;
        }

        static void sayHi(string str)
        {
            Console.WriteLine(str + " Hi" ); 
        }

        public delegate int MyGenericDelegate<T>(T agrs);

    }
}
