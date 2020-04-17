using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PageSaver
{
    class PageManipulator
    {
        public string MakeCommand (string command, string url)
        {
            //генерируем сообщение на сервер
            command = command.ToUpper();
            string host = HTMLParser.GetHost(url);
            string restUrl = HTMLParser.GetHostPath(url);
            var responseMessage = new StringBuilder();
            var message = String.Format("{0} {1} HTTP/1.1\r\nHost: {2}\r\n\r\n", command, restUrl, host);
 
            try
            {
                var port = 80;
                var serverAddr = host;
                var client = new TcpClient(serverAddr, port);
                var data = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);
                stream.Flush();
                //Console.WriteLine("Sent {0}", message);

                var buffer = new byte[1024];
                int bytesRead = 0;

                do
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    responseMessage.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                } while (stream.DataAvailable);

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption {0}", e);
            }

            return responseMessage.ToString();
        }
        
        public string GetPage(string url)
        {
            string res = MakeCommand("GET", url);

            return res;
        }


    }
}
