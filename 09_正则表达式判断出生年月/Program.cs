//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace _09_正则表达式判断出生年月
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string line = string.Empty;
//            List<string> list = new List<string>();
//            using (StreamReader reader = new StreamReader(File.Open("1_utf8.txt", FileMode.Open)))
//            {
//                using (StreamWriter sw = new StreamWriter(File.Open("2.txt", FileMode.Create)))
//                {
//                    while ((line = reader.ReadLine()) != null)
//                    {
//                        list.Add(line);
//                    }

//                    foreach (string oneline in list)
//                    {
//                        string onlyS = @"^(\d+)s$";
//                        string onlySY = @"^(\d+)s(\d+)y$";
//                        string onlyYT = @"^(\d+)y(\d+)t$";
//                        string onlyT = @"^(\d+)t$";
//                        string onlyY = @"^(\d+)y$";
//                        //string pattern1 = @"(\S/\S)(\s+\d+\s+)([10]+)";
//                        Match m = Regex.Match(oneline, onlyS); //只有岁的
//                        if (m.Success)
//                        {
//                            //Console.Write(m.Groups[1].Value);
//                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 365);
//                            continue;
//                        }

//                        m = Regex.Match(oneline, onlySY); //只有岁的
//                        if (m.Success)
//                        {
//                            //Console.WriteLine(m.Groups[1].Value);
//                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 365 + Convert.ToInt32(m.Groups[2].Value) * 30);
//                            continue;

//                        }

//                        m = Regex.Match(oneline, onlyYT); //只有岁的
//                        if (m.Success)
//                        {
//                            //Console.WriteLine(m.Groups[1].Value);
//                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 30 + Convert.ToInt32(m.Groups[2].Value));
//                            //Console.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 30 + Convert.ToInt32(m.Groups[2].Value));
//                            continue;

//                        }


//                        m = Regex.Match(oneline, onlyT); //只有天的
//                        if (m.Success)
//                        {
//                            //Console.WriteLine(m.Groups[1].Value);
//                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value));
//                            //Console.WriteLine(Convert.ToInt32(m.Groups[1].Value));
//                            continue;

//                        }

//                        m = Regex.Match(oneline, onlyY); //只有月的
//                        if (m.Success)
//                        {
//                            //Console.WriteLine(m.Groups[1].Value);
//                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 30);
//                            //Console.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 30);
//                            continue;
//                        }
//                        //string codelen = Convert.ToString(on);
//                        //Console.WriteLine(Regex.Replace(oneline, pattern, "${1}" + "\t" + codelen + "\t" + "${3}"));
//                        //sw.WriteLine(Regex.Replace(oneline, pattern, "${1}" + "\t" + codelen + "\t" + "${3}"));
//                        Console.WriteLine(oneline);
//                    }

//                }
//            }
//            Console.Read();
//        }
//    }
//}




using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09_正则表达式判断出生年月
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(File.Open("1_utf8_2.txt", FileMode.Open)))
            {
                using (StreamWriter sw = new StreamWriter(File.Open("2.txt", FileMode.Create)))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }

                    foreach (string oneline in list)
                    {
                        string onlyS = @"^(\d+)岁$";
                        string onlySY = @"^(\d+)岁(\d+)月$";
                        string onlyYT = @"^(\d+)月(\d+)天$";
                        string onlyT = @"^(\d+)天$";
                        string onlyY = @"^(\d+)月$";
                        //string pattern1 = @"(\S/\S)(\s+\d+\s+)([10]+)";
                        Match m = Regex.Match(oneline, onlyS); //只有岁的
                        if (m.Success)
                        {
                            //Console.Write(m.Groups[1].Value);
                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 365);
                            continue;
                        }

                        m = Regex.Match(oneline, onlySY); //只有岁的
                        if (m.Success)
                        {
                            //Console.WriteLine(m.Groups[1].Value);
                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 365 + Convert.ToInt32(m.Groups[2].Value) * 30);
                            continue;

                        }

                        m = Regex.Match(oneline, onlyYT); //只有岁的
                        if (m.Success)
                        {
                            //Console.WriteLine(m.Groups[1].Value);
                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 30 + Convert.ToInt32(m.Groups[2].Value));
                            //Console.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 30 + Convert.ToInt32(m.Groups[2].Value));
                            continue;

                        }


                        m = Regex.Match(oneline, onlyT); //只有天的
                        if (m.Success)
                        {
                            //Console.WriteLine(m.Groups[1].Value);
                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value));
                            //Console.WriteLine(Convert.ToInt32(m.Groups[1].Value));
                            continue;

                        }

                        m = Regex.Match(oneline, onlyY); //只有月的
                        if (m.Success)
                        {
                            //Console.WriteLine(m.Groups[1].Value);
                            sw.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 30);
                            //Console.WriteLine(Convert.ToInt32(m.Groups[1].Value) * 30);
                            continue;
                        }
                        //string codelen = Convert.ToString(on);
                        //Console.WriteLine(Regex.Replace(oneline, pattern, "${1}" + "\t" + codelen + "\t" + "${3}"));
                        //sw.WriteLine(Regex.Replace(oneline, pattern, "${1}" + "\t" + codelen + "\t" + "${3}"));
                        Console.WriteLine(oneline);
                    }

                }
            }
            Console.Read();
        }
    }
}
