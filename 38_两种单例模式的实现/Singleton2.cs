using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _38_两种单例模式的实现
{
    public class Singleton2
    {

        private static Singleton2 _s;
        private Singleton2() { }


        public static Singleton2 GetInstance()
        {
            lock ("ss") //锁住字符串，全局引用常量
            {
                if (_s == null)
                {
                    _s = new Singleton2();
                }
            }

            return _s;
            
        }


    }
}
