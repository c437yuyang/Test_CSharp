#define DoTrace //预定义必须在引入之前

using System;
using System.Collections.Generic;
using System.Diagnostics; //包括了Conditional
using System.Linq;
using System.Text;



namespace _32_特性
{
    class Program
    {
        [Conditional("DoTrace")] //类似于#ifdef的效果，只有定义了dotrace才会执行指定代码
        static void TransMsg(string str)
        {
            Console.WriteLine(str);
        }

        //sealed //sealed关键字是禁止继承的意思
        [DebuggerStepThrough] //单步调试时不进入这个方法
        static void sayHi(string msg)
        {
            Console.WriteLine(msg);
        }

        static void Main(string[] args)
        {
            //myClass1.printInfo(); //编译器会警告（报错），以过时
            myClass1.sayHello();
            TransMsg("helloa");
            Console.Read();
        }


        [Serializable]
        class myClass
        {
        }

        public static class myClass1
        {

            [Obsolete("Use sayHello function", true)] //表明方法已被遗弃,第二个参数可以直接指定为报错
            public static void printInfo()
            {

            }

            public static void sayHello()
            {
                Console.WriteLine("hello");
            }
        }

    }
}
