using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _45_01_try_catch
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Pop();
            try
            {
                s.Pop();
            }
            catch (InvalidOperationException ie)
            {
                Console.WriteLine(ie.Message);
                //throw ie;
            }
            

            Console.Read();

        }
    }
}
