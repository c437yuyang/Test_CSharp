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

namespace _21_跨线程访问窗体和join方法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // 共分三步

        // 第一步：定义委托类型
        // 将text更新的界面控件的委托类型
        //delegate void SetTextCallback(string text);
        Action<string> SetTextCallback;

        //第三步：定义更新UI控件的方法
        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetText(Object o)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.textBox1.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.textBox1.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.textBox1.Disposing || this.textBox1.IsDisposed)
                        return;
                }
                //SetTextCallback d = new SetTextCallback(SetText);
                //this.textBox1.Invoke(d, o as string);
                
                //感觉这个方法简单一些，不用用到委托（匿名） ,更简洁
                //this.textBox1.Invoke(new Action<string>((o1) =>
                //{
                //    this.textBox1.Text = o1 as string;
                //}), o);

                this.textBox1.Invoke(new Action<string>((s) =>
                {
                    this.textBox1.Text = s; //这里可以直接写成s,也不用as string
                }), o);
            }
            else
            {
                this.textBox1.Text = o as string;
            }
        }
        //之后,启动线程
        /// <summary>
        /// 启动线程按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(this.SetText);
            th.Start("aa");
        }

    }
}
