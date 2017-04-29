using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_枚举类型
{
    class Program
    {
        static void Main(string[] args)
        {
            MSG msg = MSG.REQUEST;
            Console.WriteLine(msg);
       
            Console.WriteLine((byte)msg==3); //可以直接强制类型转换来实现判断的效果
            Console.Read();
        }
    }


    enum MSG : byte //可以指定类型
    {
        SAVE_FAIL,
        SAVE_SUCCESS,
        REQUEST,
        aa
    }

}
