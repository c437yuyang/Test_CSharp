using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_匿名方法及lambda表达式
{
    class Program
    {
        static int add(int n1, int n2)
        {
            return n1 + n2;
        }
        static void Main(string[] args)
        {
            Mydelegate del = new Mydelegate(add); //委托实现
            Console.WriteLine(del(1, 2));


            Mydelegate del1 = delegate (int n1, int n2) //匿名方法实现，返回值不用管
            {
                return n1 + n2;
            };

            //lambda表达式(参数的类型省略，返回值省略)
            Mydelegate del2 = (n1,n2) => { return n1 + n2; };

            Console.WriteLine(del2(1,2));
            Console.WriteLine(del1(1,2));
            Console.Read();
        }
    }

    public delegate int Mydelegate(int n1, int n2); //必须有形参名称
}
