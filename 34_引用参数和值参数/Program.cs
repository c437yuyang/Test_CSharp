using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _34_引用参数和值参数
{
    class Program
    {

        static void increase(int age,Person p)
        {
            age++;
            p.age++;
        }

        //传引用显示指定    
        static void increase_ref(ref int age, ref Person p)
        {
            age++;
            p.age++;
        }

        static void Main(string[] args)
        {
            Person p = new Person();
            p.age = 10;
            int i = 10;
            increase(i, p);
            Console.WriteLine(i+" "+p.age);
            increase_ref(ref i, ref p);
            Console.WriteLine(i + " " + p.age);

            Console.Read();
        }
    }

    class Person {
    public int age { get; set; }
}


}
