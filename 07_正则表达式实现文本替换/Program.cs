using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_正则表达式实现文本替换
{
    class Program
    {
        static void Main(string[] args)
        {

            //FileStream fs = File.Open("a.txt", FileMode.Open);
            //StreamReader reader = new StreamReader(fs);
            //string line = string.Empty;
            //List<string> list = new List<string>();
            //using (StreamWriter sw = new StreamWriter(File.Open("b.txt", FileMode.Create)))
            //{
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        list.Add(line);

            //    }

            //    foreach (string oneline in list)
            //    {
            //        string pattern = @"(\S/\S\s)1";
            //        //Match m = Regex.Match(oneline, @"(\S/\S\s)1(.*)");
            //        //Console.WriteLine(m.Groups[0] + "," + m.Groups[1]);
            //        Console.WriteLine(Regex.Replace(oneline, pattern, "${1}"));
            //        sw.WriteLine(Regex.Replace(oneline, pattern, "${1}"));
            //    }
            //}
            //reader.Close();

            string line = string.Empty;
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(File.Open("d.txt", FileMode.Open)))
            {
                using (StreamWriter sw = new StreamWriter(File.Open("e.txt", FileMode.Create)))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }

                    foreach (string oneline in list)
                    {
                        string pattern = @"(\S/\S)(\s+\d+\s+)([10]+)";
                        Match m = Regex.Match(oneline, pattern);
                        string codelen = Convert.ToString(m.Groups[3].Length);
                        Console.WriteLine(Regex.Replace(oneline, pattern, "${1}" + "\t" + codelen + "\t" + "${3}"));
                        sw.WriteLine(Regex.Replace(oneline, pattern, "${1}" + "\t" + codelen + "\t" + "${3}"));
                    }

                }
            }


            Console.Read();

        }
    }
}
