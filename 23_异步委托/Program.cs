using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _23_异步委托
{
    class Program
    {
        static void Main(string[] args)
        {
            //异步非异步区别就是异步是新线程里进行，非异步就是直接在主线程执行

            Console.WriteLine("主线程ID：" + Thread.CurrentThread.ManagedThreadId);

            Func<int, int, int> addDel = new Func<int, int, int>((a, b) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("当前线程是:" + Thread.CurrentThread.ManagedThreadId);
                return a + b;
            });

            Console.WriteLine(addDel.Invoke(1, 2)); 
            //Console.WriteLine(addDel(1, 2)); //非异步执行

            //异步执行
            IAsyncResult result = addDel.BeginInvoke(1, 2, null, null); //执行后主线程不管他了

            //拿到异步委托的返回值
            int returnResult = addDel.EndInvoke(result); //一调用endInvoke，主线程就会暂停等待异步委托完成后才会继续
            Console.WriteLine(returnResult);
            Console.Read();

        }



    }
}
