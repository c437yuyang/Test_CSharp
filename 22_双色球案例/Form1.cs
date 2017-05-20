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

namespace _22_双色球案例
{
    public partial class Form1 : Form
    {
        List<Label> lables = new List<Label>();
        bool isRunning = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(updateLables);
            th.IsBackground = true;
            th.Start();
            isRunning = true;
        }

        void updateLables()
        {
            while (isRunning)
            {
                Random r = new Random();
                foreach(Label item in lables)
                {
                    string randNum = r.Next(1, 10).ToString();
                    if (item.InvokeRequired)
                    {
                        item.Invoke(new Action<string>((s) => { item.Text = s; })
                            , randNum);
                        //item.Invoke(,)
                    }
                    else
                    {
                        item.Text = randNum;
                    }
                }
                //Thread.Sleep(200);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i != 10; ++i)
            {
                Label l = new Label();
                l.AutoSize = true;
                l.Text = "0";
                l.Location = new Point(i * 20+20, 100);
                lables.Add(l);
                this.Controls.Add(l);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isRunning = false;
        }
    }
}
