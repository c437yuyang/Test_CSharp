using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_Path_File类
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Path.Combine("E:\\", "aaa"); //只能用\\不能用/,并且必须完全正确，不能多\或者少，感觉不如自己手动加

            //Console.WriteLine(Path.GetExtension(@"E:\websites\demo1\28_QQ好友列表.html"));
            Console.WriteLine(Path.GetExtension("E:/websites/demo1/28_QQ好友列表.html")); //两种斜杠都可以

            Console.WriteLine(Path.GetFileName("E:/websites/demo1/28_QQ好友列表.html")); //文件名+后缀名

            Console.WriteLine(Path.GetFileNameWithoutExtension("E:/websites/demo1/28_QQ好友列表.html")); //文件名不带后缀名

            Console.WriteLine(Path.GetFullPath("E:/websites/demo1/28_QQ好友列表.html")); //全路径，返回的是\\的路径

            Console.WriteLine(Path.GetDirectoryName("E:/websites/demo1/28_QQ好友列表.html")); //路径名，带前不带后

            Console.WriteLine(Path.ChangeExtension("E:/websites/demo1/28_QQ好友列表.html","jpeg")); //更换后缀名，返回全路径

            Console.WriteLine(Path.GetPathRoot("E:/websites/demo1/28_QQ好友列表.html")); //根路径E:\

            Console.WriteLine(Path.GetRandomFileName()); //随机文件名，不带路径

            Console.WriteLine(Path.GetTempFileName());//系统temp目录下生成.tmp文件

            Console.WriteLine(Path.GetTempPath());//系统temp目录

            //检查是否有文件后缀
            Console.WriteLine(Path.HasExtension("E:/websites/demo1/28_QQ好友列表.html"));
            Console.WriteLine(Path.HasExtension("E:/websites/demo1"));

            //File.Encrypt("E:/websites/demo1/28_QQ好友列表.html");
            //File.Decrypt("E:/websites/demo1/28_QQ好友列表.html");



            //Directory类
            string[] subItems = Directory.GetDirectories("e:"); //获取子目录名称(这里e:不带\\的话返回的也是不带\\的)

            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory); //应用程序路径，带前带后
            Console.WriteLine(System.Environment.CurrentDirectory ); //应用程序路径，带前不带后



            Console.Read();



        }
    }
}
