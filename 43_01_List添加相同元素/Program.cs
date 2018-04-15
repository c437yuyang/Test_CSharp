using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _43_01_List添加相同元素
{

    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Person p1 = new Person() { Age = 10, Name = "p1" };
            Person p2 = new Person() { Age = 20, Name = "p2" };
            Person p3 = new Person() { Age = 30, Name = "p3" };
            List<Person> personList = new List<Person>();

            personList.Add(p1);
            personList.Add(p1);
            personList.Add(p2);
            personList.Add(null);
            personList.Add(p2);
            personList.Add(p3);
            personList.Add(null);
            personList.Add(null); 
            personList.Add(p3);

            foreach (var person in personList)
            {
                Console.WriteLine(person != null ? person.Name : "null");
            }

            Console.Read();
        }
    }
}
