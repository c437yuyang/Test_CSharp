using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _24_生产消费者问题
{
    class Program
    {
        static void Main(string[] args)
        {
            object lockObj = new object();
            Product[] productPool = new Product[100];

            int index = 0;

            //五个生产者
            for (int i = 0; i < 5; ++i)
            {
                new Thread(() =>
                {
                    while (true)
                    {
                        lock (lockObj) //lock一个引用对象
                        {
                            if (index < 100)
                            {
                                Product p = new Product();
                                productPool[index] = p;
                                Console.WriteLine("生产一个产品:ID是{0},线程ID:{1}", index, Thread.CurrentThread.ManagedThreadId);
                                index++;
                            }
                        }
                        Thread.Sleep(200);
                    }
                }).Start();
            }

            //十个消费者
            for (int i = 0; i < 10; ++i)
            {
                new Thread(() =>
                {
                    while (true)
                    {
                        lock (lockObj) //不能锁int这种值类型，也不要去锁string,string会引起全局锁
                        {
                            if (index > 0)
                            {
                                productPool[index - 1] = null;
                                Console.WriteLine("消费一个产品:ID是{0},线程ID:{1}", index, Thread.CurrentThread.ManagedThreadId);
                                index--;
                            }
                        }

                        //下面的代码效果一样
                        //try
                        //{
                        //    Monitor.Enter(lockObj);
                        //    if (index > 0)
                        //    {
                        //        productPool[index - 1] = null;
                        //        Console.WriteLine("消费一个产品:ID是{0},线程ID:{1}", index, Thread.CurrentThread.ManagedThreadId);
                        //        index--;
                        //    }
                        //}
                        //finally
                        //{
                        //    Monitor.Exit(lockObj);
                        //}


                        Thread.Sleep(30);
                    }
                }).Start();
            }
            Console.Read();
        }
    }

    public class Product
    {

    }
}
