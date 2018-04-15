using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _44_01_ArrayList_List_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            //http://blog.csdn.net/zhang_xinxiu/article/details/8657431

            {
                ArrayList list1 = new ArrayList(); //是数组实现的版本

                //新增数据  
                list1.Add("cde");
                list1.Add(5678);

                //修改数据  
                list1[2] = 34;

                //移除数据  
                list1.RemoveAt(0);

                //插入数据  
                list1.Insert(0, "qwe");
            }

            //List，其实底层实现就是数组，所以可以理解为Java里面的ArrayList
            {
                
            }

            //LinkedList,链表实现版本
            {
                LinkedList<int> ll = new LinkedList<int>();
                ll.AddFirst(1);
                ll.AddAfter(ll.First, 2);
            }

            //总结:ArrayList什么都能装，和python的list类似，但是代价是都看做object 因此有装箱拆箱的代价
            //List就是数组实现的线性表
            //LinkedList就是链表实现的线性表


        }
    }
}
