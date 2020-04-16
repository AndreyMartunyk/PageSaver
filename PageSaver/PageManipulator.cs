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
            command = command.ToUpper();
            string host = HTMLParser.GetHost(url);
            string restUrl = HTMLParser.GetHostPath(url);
            var responseMessage = "";
            var message = String.Format("{0} {1} HTTP/1.1\r\nHost: {2}\r\n\r\n", command, restUrl, host);
 
            try
            {
                var port = 80;
                var serverAddr = host;
                var client = new TcpClient(serverAddr, port);
                var data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);
                stream.Flush();
                //Console.WriteLine("Sent {0}", message);
                

                var responseData = new byte[1024];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                responseMessage = System.Text.Encoding.ASCII.GetString(responseData, 0, bytesRead);
                //Console.WriteLine("Received {0}", responseMessage);
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption {0}", e);
            }

            return responseMessage;
        }
        
        public string GetPage(string url)
        {
            string res = MakeCommand("GET", url);

            return res;
        }


    }
}
