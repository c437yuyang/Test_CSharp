using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_使用Lambda表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 445, 5, 65, 6 };
            IEnumerable<int> emun = list.Where(Condition);
            foreach (int item in emun)
            {
                Console.WriteLine(item);
            }

            //或者
            IEnumerable<int> emun1 = list.Where(x=> { return x > 6; });
            foreach (int item in emun1)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }

        static bool Condition(int x)
        {
            return x > 6;
        }
    }
}
