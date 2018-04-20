//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    public class Path
//    {
//        public string[] PathRead()
//        {
//            string[] files;
//            string path = " ";
//            bool inputSuccess = false;
//            while (!inputSuccess)
//            {
//                path = Console.ReadLine();
//                if (Directory.Exists(path))
//                {
//                    Console.WriteLine("Путь указан неверно");
//                    path = " ";
//                }
//                if (path != " ")
//                {
//                    inputSuccess = true;
//                }
//                else
//                {
//                    continue;
//                }
//            }
//            DirectoryInfo dI = new DirectoryInfo(path);
//            FileInfo[] allFiles = dI.GetFiles();
//            int i = 0;
//            foreach (FileInfo fI in allFiles)
//            {
//                // Проверяем расширение, и если это текстовый
//                // файл - выводим его

//            }
//            string[] files = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);

//            return (files);
//        }
//        //try
//        //{
//        //    dirs = Directory.GetFiles("?.xls");
//        //    Console.WriteLine("Число файлов формата .xls: ", dirs.Length);
//        //    foreach (string dir in dirs)
//        //    {
//        //        Console.WriteLine(dir);
//        //    }
//        //}
//        //catch (Exception e)
//        //{
//        //    Console.WriteLine("The process failed: {0}", e.ToString());
//        //    //}
//        //}
//    }
//}

