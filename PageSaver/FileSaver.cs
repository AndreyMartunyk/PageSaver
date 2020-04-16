using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSaver
{
    class FileSaver
    {

        public static void CreateFile(string path, string fileName = "htmlFile.txt", string content = "")
        {
            if (path == null || path.Trim() == "")
            {
                //TODO: must be more validates
                Console.WriteLine("Create file: error path!!");
                return;
            }
            if (fileName == null || fileName.Trim() == "")
            {
                //TODO: must be more validates
                Console.WriteLine("Create file: error file name!!");
                return;
            }
            if (path[path.Length - 1] != '\\')
            {
                path += "\\";

            }

            StreamWriter sw = new StreamWriter(path + fileName, false, System.Text.Encoding.Default);
            sw.Write(content);
            sw.Flush();
            Console.WriteLine("file \"{0}\" is ready!", fileName);
        }

    }
}
