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

namespace _10_xml写入与读取
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xmlDoc.AppendChild(xmlDec);
            XmlElement rootElem = xmlDoc.CreateElement("school");
            xmlDoc.AppendChild(rootElem);

            XmlElement classElem = xmlDoc.CreateElement("class");
            XmlAttribute classAttr = xmlDoc.CreateAttribute("id");
            classAttr.Value = "01";
            classElem.Attributes.Append(classAttr);
            rootElem.AppendChild(classElem);

            XmlElement stuElem = xmlDoc.CreateElement("student");
            XmlAttribute stuAttr = xmlDoc.CreateAttribute("sid");
            stuAttr.Value = "01";
            stuElem.Attributes.Append(stuAttr);
            classElem.AppendChild(stuElem);

            XmlElement stuName = xmlDoc.CreateElement("Name");
            stuName.InnerText = "yxp";
            stuElem.AppendChild(stuName);
            XmlElement stuAge = xmlDoc.CreateElement("Age");
            stuAge.InnerText = "21";
            stuElem.AppendChild(stuAge);

            xmlDoc.Save("a.xml");
            MessageBox.Show("保存成功!");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Person> list = new List<Person>();
            list.Add(new _10_xml写入与读取.Person() { name = "yxp", age = 180, Email = "954222619@qq.com" });
            list.Add(new _10_xml写入与读取.Person() { name = "yxp1", age = 181, Email = "9542226119@qq.com" });
            list.Add(new _10_xml写入与读取.Person() { name = "yxp2", age = 182, Email = "9542226119@qq.com" });
            list.Add(new _10_xml写入与读取.Person() { name = "yxp3", age = 183, Email = "9542222619@qq.com" });

            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmldec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement rootElem = xmlDoc.CreateElement("person");
            xmlDoc.AppendChild(rootElem);

            foreach(Person p in list)
            {
                XmlElement pElem = xmlDoc.CreateElement(p.name);
                XmlAttribute attr = xmlDoc.CreateAttribute("age");
                attr.Value = p.age.ToString();
                pElem.Attributes.Append(attr);
                XmlElement pElemEmail = xmlDoc.CreateElement("email");
                pElemEmail.InnerText = p.Email;
                pElem.AppendChild(pElemEmail);
                rootElem.AppendChild(pElem);
            }
            xmlDoc.Save("b.xml");
            MessageBox.Show("写入成功!");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Person> list = new List<Person>();
            list.Add(new _10_xml写入与读取.Person() { name = "yxp", age = 180, Email = "954222619@qq.com" });
            list.Add(new _10_xml写入与读取.Person() { name = "yxp1", age = 181, Email = "9542226119@qq.com" });
            list.Add(new _10_xml写入与读取.Person() { name = "yxp2", age = 182, Email = "9542226119@qq.com" });
            list.Add(new _10_xml写入与读取.Person() { name = "yxp3", age = 183, Email = "9542222619@qq.com" });

            XDocument xDoc = new XDocument();
            XDeclaration xdec = new XDeclaration("1.0", "utf-8", null);
            XElement rootElem = new XElement("List");
            xDoc.Add(rootElem);
            xDoc.Declaration = xdec;
            
            //1.循环创建根节点
            for(int i = 0; i < list.Count; ++i)
            {
                XElement elemPerson = new XElement("Person");
                elemPerson.SetAttributeValue("id", (i + 1).ToString());
                elemPerson.SetElementValue("name", list[i].name);
                elemPerson.SetElementValue("age", list[i].age.ToString());
                elemPerson.SetElementValue("email", list[i].Email);
                rootElem.Add(elemPerson);
            }
            xDoc.Save("c.xml");
        }
    }


    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
    }
}
