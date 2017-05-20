using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_事件
{
    public partial class UserBtn : UserControl
    {
        public UserBtn()
        {
            InitializeComponent();
        }

        //按钮作为事件发布者，发布一个事件，需要订阅者去实现这个事件
        public event Action TripleClick;
        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            if(count >= 3)
            {
                if(TripleClick!=null)
                    TripleClick();
                count = 0;
            }
        }
    }
}
