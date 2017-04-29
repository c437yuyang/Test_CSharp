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
            
        }
    }
}
