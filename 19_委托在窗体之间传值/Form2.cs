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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void setText(string str)
        {
            this.textBox1.Text = str;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
