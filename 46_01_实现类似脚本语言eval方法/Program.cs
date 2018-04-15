using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _46_01_实现类似脚本语言eval方法
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1.CSharpCodePrivoder 
            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();
            // 2.ICodeComplier 
            ICodeCompiler objICodeCompiler = objCSharpCodePrivoder.CreateCompiler();
            // 3.CompilerParameters 
            CompilerParameters objCompilerParameters = new CompilerParameters();
            objCompilerParameters.ReferencedAssemblies.Add("System.dll");
            objCompilerParameters.GenerateExecutable = false;
            objCompilerParameters.GenerateInMemory = true;
            // 4.CompilerResults
            CompilerResults cr = objICodeCompiler.CompileAssemblyFromSource(objCompilerParameters, GenerateCode());
            if (cr.Errors.HasErrors)
            {
                Console.WriteLine("编译错误：");
                foreach (CompilerError err in cr.Errors)
                {
                    Console.WriteLine(err.ErrorText);
                }
            }
            else
            {
                // 通过反射，调用HelloWorld的实例 
                Assembly objAssembly = cr.CompiledAssembly;
                object objHelloWorld = objAssembly.CreateInstance("DynamicCodeGenerate.HelloWorld");// 这里和下面的具体的代码里的namespace和class对应
                MethodInfo objMI = objHelloWorld.GetType().GetMethod("OutPut"); //获得指定的方法
                Console.WriteLine("执行结果:" + objMI.Invoke(objHelloWorld, null)); //调用Invoke执行
            }

            Console.ReadLine();
        }

        static string GenerateCode()
        {
            //可以看到还是挺麻烦的其实，因为这里始终你得导入那些命名空间这些，所以不像脚本语言那么方便
            //而且如果要添加引用该怎么办?
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;");
            sb.Append(Environment.NewLine);
            sb.Append("namespace DynamicCodeGenerate");
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append(" public class HelloWorld");
            sb.Append(Environment.NewLine);
            sb.Append(" {");
            sb.Append(Environment.NewLine);
            sb.Append("public int i1 = 1 ;");
            sb.Append(Environment.NewLine);
            sb.Append("public int i2 = 3 ;");
            sb.Append(Environment.NewLine);
            sb.Append(" public string OutPut()");
            sb.Append(Environment.NewLine);
            sb.Append(" {");
            sb.Append(Environment.NewLine);
            sb.Append(" return (i1 + i2).ToString();");
            sb.Append(Environment.NewLine);
            sb.Append(" }");
            sb.Append(Environment.NewLine);
            sb.Append(" }");
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            Console.WriteLine(code);
            Console.WriteLine();
            return code;
        }
    }
}
