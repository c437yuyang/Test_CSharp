using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _33_访问控制修饰符
{
    class Program
    {
        static void Main(string[] args)
        {

            //1.成员:默认和显示private都是私有
            //2.类：默认是internal,只能被同一个程序集的访问，只有public 和internal
            // 3.成员:public private protected和c++,java一致，
            // internal是程序集内部可见，internal protected是程序集内部或者派生类可见
            // (不是类的对象可以访问，只是类可以访问而已)
        }
    }
}
