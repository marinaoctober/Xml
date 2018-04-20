using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp1
{    
    [Serializable]
    [XmlRoot("folder")]
    public class FolderList
    {
        [XmlElement("folder")]
        public List<Folder> Folders { get; set; }

    }

    [Serializable]
    public class Folder
    {       
        [XmlElement("str")]
        public List<Param> Params { get; set; }
        [XmlElement("int")]
        public List<Count> Counts { get; set; }
    }

    [Serializable]
    public class Param
    {
        //[XmlElement("folder/str")]
        //public string Str { get; set; }
        [XmlAttribute("name")]
        public string NameStr { get; set; }
        //[XmlAttribute("value")]
        //public string Val { get; set; }
        //[XmlAttribute("value")]
        //public Oper Val { get; set; }

        //[XmlIgnoreAttribute]
        //public string Uid { get; set; }

        [XmlAttribute("value")]
        public Oper Operand { get; set; }
    }

    [Serializable]
    public class Count
    {
        [XmlAttribute("name")]
        public string NameInt { get; set; }
        [XmlAttribute("value")]
        public string Val { get; set; }
    }

    public enum Oper
    {
        [XmlEnum(Name = "add")]
        add,
        [XmlEnum(Name = "subtract")]
        subtract,
        [XmlEnum(Name = "multiply")]
        multiply,
        [XmlEnum(Name = "divide")]
        divide,
    }

    public class Operation
    {
        public double MathOp(double x, double y, Oper op)
        {
            double res = 0.0;

            switch (op)
            {
                case Oper.add:
                    res = x + y;
                    break;
                case Oper.subtract:
                    res = x - y;
                    break;
                case Oper.multiply:
                    res = x * y;
                    break;
                case Oper.divide:
                    res = x / y;
                    break;
            }
            return res;
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите путь к файлу");
            XmlSerializer xmlDes = new XmlSerializer(typeof(FolderList));
            FolderList results;
            Path check = new Path();
            string path = check.PathRead();
            //string path = (@"C:\Users\kovsh\Documents\Visual Studio 2017\sampleData.xml");
            Operation op = new Operation();
            using (FileStream fileStream = new FileStream(path, FileMode.Open))//Работает, если задать path в самой программе, а не через класс
            {
                results = (FolderList)xmlDes.Deserialize(fileStream);
                Console.WriteLine(results.Folders[1].Params);
               
            }

            double res = 0.0;
            for (int i = 0; i <= results.Folders.Count - 1; i++)
            {
                double y = Convert.ToDouble(results.Folders[i].Counts[0].Val);
                res = op.MathOp(res, y, results.Folders[i].Params[0].Operand);               
            }
            Console.WriteLine("Для файла по адресу: " + path + "\nОтвет: " + res);
            Console.ReadKey();
            //Все, что описано ниже - это наработки по работе с xml файлами. Из них можно вытащить инфу без десериализации
            //Path files = new Path();
            //string path = files.PathRead();

            //XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(line));
            //Console.WriteLine(reader);
            //System.IO.DirectoryInfo info = new System.IO.DirectoryInfo("D:\\Прога");
            //System.IO.DirectoryInfo[] dirs = info.GetDirectories();
            //System.IO.FileInfo[] files = info.GetFiles();
            //string[] files = Directory.GetFiles(@"D:\Прога", "*.xml", SearchOption.AllDirectories);
            //for (int i = 0; i < files.Length; i++)
            //{
            //    Console.WriteLine(files[i]);
            //}

            //XmlDocument xdoc = new XmlDocument();
            //{
            //try
            //{
            //    xdoc.Load(path);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Ошибка: ");
            //    Console.WriteLine(ex.Message);
            //}
            //XmlNodeList listOfCalcs = xdoc.SelectNodes("/folder/folder");
            //foreach (XmlNode SingleCalc in listOfCalcs)
            //{
            //    foreach (XmlNode x in SingleCalc.ChildNodes)
            //    {
            //        if (x != null)
            //        {
            //            Console.WriteLine("name: " + x.Attributes["name"].Value + "; Value: " + x.Attributes["value"].Value);                        
            //        }
            //    }
            //}            
            //XmlTextReader reader = new XmlTextReader(path);
            ////Sample node = new Sample();
            ////node.WorkWithNodes(path);

        }   
    }
}


