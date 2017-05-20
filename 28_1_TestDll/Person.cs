using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_1_TestDll
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }

        public Person() { }
        public Person(string name,int age)
        {
            this.name = name;
            this.age = age;
        }

        public void sayHi()
        {
            Console.WriteLine("Hi");
        }

        public void sayHello()
        {
            Console.WriteLine("SayHello 无参数版本");
        }

        public void sayHello(string msg)
        {
            Console.WriteLine("SayHello:" + msg);
        }
    }
    public class Person1
    {
        public string name { get; set; }
        public int age { get; set; }

        public void sayHi()
        {
            Console.WriteLine("Hi");
        }
    }

    public delegate void Mydel();

    internal class Teacher : Person
    {

    }

    public struct Mystrcut
    {

    }
   
    public enum myEnum
    {

    }
}
