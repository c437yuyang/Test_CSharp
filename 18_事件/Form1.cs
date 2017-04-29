using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_事件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void userBtn1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //事件只能用+=或-=来赋值,事件不能被直接调用（不要看那个函数，要看具体的action）,只能被声明事件的类调用
            //委托可以用=赋值，之前注册的事件都回被覆盖
            userBtn1.TripleClick += () =>
            {
                MessageBox.Show("被点击了");
            };
        }
    }
}
