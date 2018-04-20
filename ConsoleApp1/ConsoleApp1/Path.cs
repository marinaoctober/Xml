using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Path
    {
        public string PathRead() // Метод для обработки ввода пути к файлу!(не к директории)
        {
            string path = " ";
            bool inputSuccess = false;
            while (!inputSuccess)
            {
                path = Console.ReadLine();
                if (Directory.Exists(path))
                {                    
                    Console.WriteLine("Путь указан неверно");
                    path = " ";
                }
                if (path != " ")
                {
                    inputSuccess = true;
                }
                else
                {
                    continue;
                }
            }
            return (path);
        }
    }
}
