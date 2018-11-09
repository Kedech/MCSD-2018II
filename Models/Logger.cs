using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WebServerProj
{
    public static class Logger
    {
        public static void Log(string message, Stream data)
        {
            var fixedMessage = $"{DateTime.Now.ToString()}-{message}";
            Console.WriteLine(fixedMessage);
            AddLineToLog(fixedMessage);
            CopyMessageToFile(data);
        }

        private static void AddLineToLog(string message)
        {
            using (FileStream fs = File.OpenWrite("E:\\Lourtec\\Log.txt"))
            {
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(message);
                }
            }
        }

        private static void CopyMessageToFile(Stream message)
        {
            var memoryStream = message;

            var fileStream = File.OpenWrite($"E:\\Lourtec\\Log-{DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss")}.txt");
            memoryStream.CopyTo(fileStream);
            fileStream.Close();

            //using (var stream = File.OpenWrite("E:\\Lourtec\\Log.txt"))
            //{
            //    memoryStream.CopyTo(fileStream);
            //}
        }
    }
}