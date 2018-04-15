using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _28_反射
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 获取成员

            //方法1.有对象的时候
            Person p = new Person();
            Type type1 = p.GetType();

            //2.方法2
            Type type2 = typeof(Person);
            FieldInfo[] fields = type2.GetFields(); //只能获取共有字段
            for (int i = 0; i != fields.Length; ++i)
            {
                Console.WriteLine(fields[i]);
            }

            ////公有属性
            //PropertyInfo[] props = type2.GetProperties();
            //for (int i = 0; i != props.Length; ++i)
            //{
            //    Console.WriteLine(props[i]);
            //}

            ////公有方法
            //MemberInfo[] methods = type2.GetMethods();
            //for (int i = 0; i != methods.Length; ++i)
            //{
            //    Console.WriteLine(methods[i]);
            //}
            #endregion

            //动态加载程序集
            Assembly asm = Assembly.LoadFile(@"I:\My Documents\My Desktop\codes\CSharp\Demos_CSharp\28_1_TestDll\bin\Debug\28_1_TestDll.dll");
            //1.1获取程序集的所有类型(包括私有)
            Type[] types = asm.GetTypes();
            for (int i = 0; i != types.Length; ++i)
            {
                Console.WriteLine(types[i]);
            }

            //1.2获取public类型
            Type[] types1 = asm.GetExportedTypes();
            Console.WriteLine("public:");
            for (int i = 0; i != types1.Length; ++i)
            {
                Console.WriteLine(types1[i]);
            }

            //1.3获取指定类型(命名空间+类名)
            Type typePerson = asm.GetType("_28_1_TestDll.Person");
            //调用这个类的方法
            MethodInfo mi = typePerson.GetMethod("PublicMethod");
            //创建person的对象
            object obj = Activator.CreateInstance(typePerson);
            mi.Invoke(obj, null); //第一个参数是一个实例，若是静态方法传null，第二个参数就是函数的参数

            MethodInfo hello = typePerson.GetMethod("PrivateMethod", new Type[] { typeof(string) }); //这样也可以访问私有方法
            //如果方法有返回值的话，直接接收Invoke的返回值就可以了
            hello.Invoke(Activator.CreateInstance(typePerson), new object[] { "aaa" });

            //2.创建类的对象的其他方法
            object obj1 = Activator.CreateInstance(typePerson); //这个方法只能调用无参构造函数
                                                             //调用指定构造函数来创建对象
            ConstructorInfo[] cis = typePerson.GetConstructors();
            ConstructorInfo ci = typePerson.GetConstructor(new Type[] { typeof(string), typeof(int) });

            object obj2 = ci.Invoke(new object[] { "yxp", 20 });
            PropertyInfo pInfo = typePerson.GetProperty("name");
            Console.WriteLine(pInfo.GetValue(obj2,null));
        }

        public class Person
        {
            private string[] _bfs;
            public string[] _gfs;

            public string name { set; get; }
            public void PublicMethod()
            {
                Console.WriteLine("Hi");
            }

            private void PrivateMethod()
            {
                Console.WriteLine("Hello");
            }

        }
    }
}
