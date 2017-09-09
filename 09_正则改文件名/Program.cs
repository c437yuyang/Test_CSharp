using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _09_正则改文件名
{
    class Program
    {
        //这个例子是当时评价表需要批量重命名的时候(井波的格式错了)
        static void Main(string[] args)
        {
            string path = @"I:\My Documents\My Desktop\开学\勤工俭学\评价表第二波_5_20\复查表15-16（下）-梁";
            string[] files = Directory.GetFiles(path);

            foreach (var filePath in files)
            {
                string filename = Path.GetFileName(filePath);

                string pattern = @"(\S+)(\s)(\d+)(\s)(\d+)(\..+)";
                Match m = Regex.Match(filename, pattern); //只有岁的

                string newName = m.Groups[3] + "_"  +m.Groups[5]+ m.Groups[6];

                string newPath = path + @"\" + newName;
                File.Move(filePath, newPath);
            }

        }
    }
}
