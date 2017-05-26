using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _28_1_反射创建对象
{
    class Program
    {
        static void Main(string[] args)
        {
            //3.反射创建对象的另一种方法
            Assembly asm1 = Assembly.Load("28_1_TestDll"); //程序集名称
            _28_1_TestDll.Person p = asm1.CreateInstance("_28_1_TestDll.Person") //命名空间+类型名称
                as _28_1_TestDll.Person;
            //注意前面的程序集名称不一定和命名空间一样，这里就是个例子
            p.sayHello();

            Console.Read();
        }
    }
}
