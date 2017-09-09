using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _40_01_引用类型在容器的contain方法里的表现
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> list = new List<Person>() {
                new Person() {age=10},new Person() { age=20}
            };

            Person person = new Person() { age = 10 };

            Console.WriteLine(list.Contains(person)); //false，说明引用类型还是不是同一个对象，就算数据一样
            Console.WriteLine(list.Contains<Person>(person));//false，说明引用类型还是不是同一个对象，就算数据一样

            List<Person1> list1 = new List<Person1>() {
                new Person1() {age=10},new Person1() { age=20}
            };

            Person1 person1 = new Person1() { age = 10 };

            Console.WriteLine(list1.Contains(person1)); //true，改写了equals方法便可以实现自己想要的比较


        }

        class Person
        {
            public int age { get; set; }
        }

        class Person1
        {
            public int age { get; set; }
            public override bool Equals(object obj)
            {
                Person1 p = obj as Person1;
                return p.age == this.age;
            }
        }

    }
}
