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

        private Action<string> delSetText;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new _19_委托在窗体之间传值.Form2();
            delSetText+=form2.setText;
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delSetText(this.textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
