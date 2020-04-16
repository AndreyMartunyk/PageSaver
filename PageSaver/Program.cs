using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSaver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!!\nWhich site would you like to save into file: ?");
            string link = "http://selin.in.ua/solvve/html.html";
            //string link = Console.ReadLine();
            Console.WriteLine("link:{0} saved", link);

            PageManipulator pm = new PageManipulator();
            string content = HTMLParser.CutHead(HTMLParser.CutAfterHTML(pm.GetPage(link)));

            Console.WriteLine("Enter the file path : ?");
            string path = @"C:\Users\User\Desktop";
            //string path = Console.ReadLine();
            Console.WriteLine("path:{0} saved", path);

            Console.WriteLine("Enter the file name : ?");
            string fileName = "myHTML.txt";
            //string fileName = Console.ReadLine();
            Console.WriteLine("fileName:{0} saved", fileName);

            FileSaver.CreateFile(path, fileName, content);

            Console.ReadKey();
        }

      
    }
}
