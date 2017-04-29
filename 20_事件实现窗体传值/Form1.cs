using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20_事件实现窗体传值
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public event EventHandler evt;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (evt != null)
            {
                evt(this, new MyEventArgs() { str = this.textBox1.Text });
            }
        }
    }
}
