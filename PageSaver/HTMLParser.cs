using System;

namespace PageSaver
{
    static class HTMLParser
    {
        public static string CutHead(string package)
        {
            try
            {
                package = package.Substring(package.IndexOf("\r\n\r\n")).Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine("HTMLParser: Exeption {0}", e);
            }

            return package;
        }

        public static string GetHost(string url)
        {
            url = CutHTTP(url);
            if (url.Contains("/"))
            {
                url = url.Substring(0, url.IndexOf('/'));
            }

            return url;
        }

        public static string GetHostPath(string url)
        {
            url = CutHTTP(url);
            if (url.Contains("/"))
            {
                url = url.Substring(url.IndexOf('/'));
            }
            else
            {
                url = "/";
            }

            return url;
        }

        private static string CutHTTP(string url)
        {
            if (url.Trim().ToLower().Contains("http://") || url.Trim().ToLower().Contains("https://")){
                url = url.Substring(url.IndexOf('/') + 2);
            }

            return url;
        }



    }
}
