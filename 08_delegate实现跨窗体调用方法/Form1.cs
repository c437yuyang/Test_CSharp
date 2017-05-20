using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08_delegate实现跨窗体调用方法
{
    public partial class Form1 : Form
    {
        public static int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(updateLable,updateLable,updateLable1,this);
            form2.Show();
        }

        public void updateLable()
        {
            ++i;
            labelX1.Text = Convert.ToString(i);
        }

        void updateLable(string s)
        {
            labelX1.Text = s;
        }

        int updateLable1(string s)
        {
            labelX1.Text = s;
            return 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //窗体给那边加一个时间也可以实现
            Form3 form3 = new Form3();
            form3.updateLabel += updateLable;
            form3.Show();

        }
    }
}
