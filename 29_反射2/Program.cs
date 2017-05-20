using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_反射2
{
    class Program
    {
        static void Main(string[] args)
        {
            Type typePerson = typeof(Person);
            Type typeTeacher = typeof(Teacher);
            Type typeStudent = typeof(Student);

            //检查不同对象是否能赋值
            Console.WriteLine(typePerson.IsAssignableFrom(typeTeacher));
            Console.WriteLine(typePerson.IsAssignableFrom(typeStudent));
            Console.WriteLine(typeStudent.IsAssignableFrom(typeTeacher));

            object objPerson = Activator.CreateInstance(typePerson);
            object objTeacher = Activator.CreateInstance(typeTeacher);
            object objStudent = Activator.CreateInstance(typeStudent);

            //检查是否是某个对象
            Console.WriteLine(typePerson.IsInstanceOfType(objPerson));
            Console.WriteLine(typePerson.IsInstanceOfType(objTeacher));
            Console.WriteLine(typePerson.IsInstanceOfType(objStudent));

            //检查子类父类(但是不能检查接口)
            Console.WriteLine(typeTeacher.IsSubclassOf(typePerson));

            //检查是不是抽象类(含接口)
            Console.WriteLine(typePerson.IsAbstract); 

            Console.Read();
        }
    }


    public class Person
    {
        string name { get; set; }
        int age { get; set; }

    }

    public class Teacher : Person
    {

    }

    public class Student : Person
    {

    }
}
