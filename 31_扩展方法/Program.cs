using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_扩展方法
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.SayHello();
            p.SayHello("hha");
            //1.定义扩展方法，就是在一个静态类里面新增一个静态方法，然后参数前面加一个this,代表为这个类新增一个扩展方法
            //2.甚至可以直接为系统的类增加扩展方法，比如string类，一样的前面加this就行了
             
            
            //隐式类型（不推荐使用）

            var p1 = new //直接new一个列表就是一个对象了，但是不能用Lambda表达式增加方法
            {
                Name = "yxp",
                age = 18
            };

            Console.Read();

        }
    }

    public class Person
    {
        public string name;
        public int age;
        private string nickName;
    }

    public static class ExtFunc
    {
        public static void SayHello(this Person p)
        {
            Console.WriteLine(p.name + "说:大家好.");
        }

        public static void SayHello(this Person p, string msg) //第二个参数就是真正的参数,有两个参数的话可以再加
        {
            Console.WriteLine(p.name + "说:大家好." + msg);
        }
    }


}
