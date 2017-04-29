using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_delegate实现跨窗体调用方法
{
    public delegate void UpdateLabelDelegate();
    public delegate void UpdateLabelDelegateStr(string s);
    public delegate int UpdateLabelDelegateStrReturn(string s);
}
