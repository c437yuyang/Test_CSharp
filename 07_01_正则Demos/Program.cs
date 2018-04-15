using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_01_正则Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex("[:digit:]+");

            //string str = "123"; //不能匹配，C#里面不支持这种语法，只支持\d这些

            string str = "[:digit:]"; //这样就匹配了，验证了上面的说法

            //Console.WriteLine(pattern.Match(str).Groups[0].Value);

            Console.WriteLine(pattern.IsMatch(str));


        }
    }
}
