using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _35_GUI异步
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Text = "doing sth ing....";

            Thread.Sleep(4000);
            label1.Text = "not doing anythin";
            button1.Enabled = true;

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            label1.Text = "doing sth ing....";

            await Task.Delay(4000);
            label1.Text = "not doing anythin";
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            label1.Text = "doing sth ing....";

            Action delay = new Action(() =>
            {
                Thread.Sleep(4000);
            });

            IAsyncResult result = delay.BeginInvoke(null, null);
            

            label1.Text = "not doing anythin";
            button3.Enabled = true;
            delay.EndInvoke(result); //点击可以看到按钮立马就恢复了可用，可以看到主线程没有在等待，而是让子线程自己控制
        }
    }
}
