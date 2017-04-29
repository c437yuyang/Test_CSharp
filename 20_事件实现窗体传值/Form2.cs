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
    public partial class Form2 : Form
    {
        public Form2(Form1 form)
        {
            InitializeComponent();
            form.evt += this.setText;
        }

        private void setText(object sender, EventArgs e)
        {
            MyEventArgs args = e as MyEventArgs;
            this.textBox1.Text = args.str;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
