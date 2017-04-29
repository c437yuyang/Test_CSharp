using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace _11_递归加载xml文件到treeview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            XDocument xDoc = XDocument.Load("../../岩屑标准模板.xml");
            XElement rootElem = xDoc.Root;
            TreeNode rootNode = treeView1.Nodes.Add(rootElem.Name.ToString());
            LoadXmlToTreeView(rootElem, rootNode.Nodes);

        }

        private void LoadXmlToTreeView(XElement rootElem, TreeNodeCollection nodes)
        {
            foreach (XElement xmlElem in rootElem.Elements())
            {
                if (xmlElem.Elements().Count() == 0)
                {
                    nodes.Add(xmlElem.Name.ToString()).Nodes.Add(xmlElem.Value);
                }
                else
                {
                    TreeNode node = nodes.Add(xmlElem.Name.ToString());
                    LoadXmlToTreeView(xmlElem, node.Nodes);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("../../岩屑标准模板.xml");
            XmlElement rootElem = xDoc.DocumentElement;

            TreeNode rootNode = treeView1.Nodes.Add(rootElem.Name.ToString());
            LoadXmlToTreeView1(rootElem, rootNode.Nodes);
        }

        /// <summary>
        /// 标准的dom方式
        /// </summary>
        /// <param name="rootElem"></param>
        /// <param name="nodes"></param>
        private void LoadXmlToTreeView1(XmlElement rootElem, TreeNodeCollection nodes)
        {
            foreach (XmlNode item in rootElem.ChildNodes)
            {
                if (item.NodeType == XmlNodeType.Element)
                {
                        TreeNode node = nodes.Add(item.Name);
                        LoadXmlToTreeView1((XmlElement)item, node.Nodes);
                }
                else if(item.NodeType==XmlNodeType.CDATA || item.NodeType == XmlNodeType.Text)
                {
                    nodes.Add(item.InnerText);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("../../岩屑标准模板.xml");
            XmlNodeList list =  xDoc.GetElementsByTagName("FontName");
            foreach(XmlNode item in list)
            {
                Console.WriteLine(item.InnerText);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("../../岩屑标准模板.xml");
            XElement rootElem = doc.Root;
            //foreach(var item in rootElem.Elements())
            //{
            //    Console.WriteLine(item.Name);
            //}
            Console.WriteLine(rootElem.Element("绘道参数").Element("Column0").Element("name").Value);
            
        }
    }
}
