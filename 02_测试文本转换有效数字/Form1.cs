using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_测试文本转换有效数字
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //double d = Convert.ToDouble(textBox1.Text);
            try
            {
                double d = Double.Parse(textBox1.Text);
                double d1 = Convert.ToDouble(textBox1.Text);
                Console.WriteLine(d);
                Console.WriteLine(d1);
            }
            catch (Exception) { Console.WriteLine("无效数字"); }
            Console.WriteLine("do"); //可以看到catch到了异常后，还是会继续执行代码的
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //测试超出INT最大值的long转换成int会不会报错
            //会抛出System.OverflowException异常
            long lvalue = Convert.ToInt64((int.MaxValue)) + 1;
            int shvalue = 0;
            try
            {
                shvalue = Convert.ToInt32(lvalue);
            }
            catch
            {
                Console.WriteLine("数据出错，溢出!");
            }

        }
    }
}
