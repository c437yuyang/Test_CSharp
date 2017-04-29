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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private UpdateLabelDelegate _updateLable;
        private UpdateLabelDelegateStr _updateLableStr;
        private UpdateLabelDelegateStrReturn _updateLableStrReturn;
        private Form1 _form1;

        public Form2(UpdateLabelDelegate method,UpdateLabelDelegateStr method1,UpdateLabelDelegateStrReturn method2,Form1 form1):this()
        {
            this._updateLable = method;
            this._updateLableStr = method1;
            this._updateLableStrReturn = method2;
            this._form1 = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_updateLable != null)
            {
                _updateLable();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_updateLableStr != null)
            {
                _updateLableStr(textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_updateLableStrReturn != null)
            {
                Console.WriteLine(_updateLableStrReturn(textBox1.Text)); 
            }
        }

        //直接调用public函数，但是这样不安全，把窗口传了过来的话后面用户想干什么干什么
        private void button4_Click(object sender, EventArgs e)
        {
            _form1.updateLable();
        }
    }
}
