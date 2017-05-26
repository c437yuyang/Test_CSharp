using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _38_两种单例模式的实现
{
    public class Singleton1
    {

        public static readonly Singleton1 _s;

        private Singleton1() { }


        //CLR保证了静态函数只被执行一次且是线程安全的
        static Singleton1()
        {
            _s = new Singleton1();
        }



    }
}
