using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19_委托在窗体之间传值
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Form2 form2 = new _19_委托在窗体之间传值.Form2();
        private Action<string> delSetText;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new _19_委托在窗体之间传值.Form2();
            delSetText +=form2.setText;
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delSetText(this.textBox1.Text);
            //form2.setText(this.textBox1.Text);//本身窗体2是只提供一个可以修改text的方法的，但是如果使用这个方法，则所有form2的共有成员都会被访问到
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
