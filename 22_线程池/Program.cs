using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22_线程池
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        //线程池的优势:1.都是后台线程
        //2.线程可以进行重用
        // 线程池的缺点：1.不够灵活，外部不能访问线程，不能abort以及执行顺序不确定
        // 线程池:适合做大量非常小的运算，就是放进去就不管的那种
        static void Main()
        {
            Console.WriteLine("主线程ID：" + Thread.CurrentThread.ManagedThreadId);
            ThreadPool.QueueUserWorkItem(s =>
            {
                Console.WriteLine(s);
            },"ss");

            int i, j;
            ThreadPool.GetMaxThreads(out i, out j);


            //dotnet4.0新引入的使用线程池的技术
            //Task t1 = new Task(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("当前线程ID：" + Thread.CurrentThread.ManagedThreadId);
            //});
            //t1.Start();
            //t1.Wait(); //让主线程停下来等待工作完成


            //另一种方法:
            Task t1 =Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("当前线程ID：" + Thread.CurrentThread.ManagedThreadId);
            });


            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("当前线程ID：" + Thread.CurrentThread.ManagedThreadId);
            });

            Task t3 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("当前线程ID：" + Thread.CurrentThread.ManagedThreadId);
            });

            //t1.Wait(); //让主线程停下来等待工作完成
            Task.WaitAll(t1, t2, t3); //等待所有的完成
            Task.WaitAny(t1, t2, t3);//一个完成就向下继续执行

            Console.WriteLine("主线程完成");

            Console.Read();
        }
    }
}
