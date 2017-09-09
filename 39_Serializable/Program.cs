using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

//要添加引用

//using System.Runtime.Serialization.Formatters.Binary;


//除了标记为NonSerialized的其他所有成员都能序列化
public class Test
{
    public static void Main()
    {
        // 三种序列化对比:Binary模式不生成xml文件,
        // soap模式保存成特殊协议的xml文件，支持不序列化nonserialize标签的属性
        // xml模式不支持不序列化nonserialize标签的属性
        // 

        //Creates a new TestSimpleObject object.
        TestSimpleObject obj = new TestSimpleObject();

        Console.WriteLine("Before serialization the object contains: ");
        obj.Print();

        //Opens a file and serializes the object into it in binary format.
        //Stream stream = File.Open("data_xml.xml", FileMode.Create);
        Stream stream = File.Open("data_soap.xml", FileMode.Create);

        SoapFormatter formatter = new SoapFormatter();
        //BinaryFormatter formatter = new BinaryFormatter();
        //XmlSerializer formatter = new XmlSerializer(typeof(TestSimpleObject));


        formatter.Serialize(stream, obj);
        stream.Close();

        //Empties obj.
        obj = null;

        //Opens file "data.xml" and deserializes the object from it.
        //stream = File.Open("data_xml.xml", FileMode.Open);
        stream = File.Open("data_soap.xml", FileMode.Open);

        formatter = new SoapFormatter();
        //formatter = new BinaryFormatter();
        //formatter = new XmlSerializer(typeof(TestSimpleObject));

        obj = (TestSimpleObject)formatter.Deserialize(stream);
        stream.Close();

        Console.WriteLine("");
        Console.WriteLine("After deserialization the object contains: ");
        obj.Print();
        Console.Read();
    }
}


// A test object that needs to be serialized.
[Serializable()]
public class TestSimpleObject
{

    public int Member1;
    public string Member2;
    public string Member3;
    public double Member4;

    // A field that is not serialized.
    [NonSerialized()]
    public string Member5;

    public TestSimpleObject()
    {

        Member1 = 11;
        Member2 = "hello";
        Member3 = "hello";
        Member4 = 3.14159265;
        Member5 = "hello world!";
    }


    public void Print()
    {
        Console.WriteLine("member1 = '{0}'", Member1);
        Console.WriteLine("member2 = '{0}'", Member2);
        Console.WriteLine("member3 = '{0}'", Member3);
        Console.WriteLine("member4 = '{0}'", Member4);
        Console.WriteLine("member5 = '{0}'", Member5);
    }
}