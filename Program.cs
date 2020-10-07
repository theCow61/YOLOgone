using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;

namespace Spam
{
    class Program
    {
        static string yoloID { get; set; }
        static string textToSend { get; set; }
        static void lul(string[] args)
        {
            int sentCount = 0;
            int maxCount = 0;
            void sendRequest()
            {
                if (sentCount == maxCount)
                {
                    return;
                }
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://onyolo.com/" + yoloID + "/message");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"text\":\"" + textToSend + "\",\"cookie\":\"5w5j5djvvk3snnf5llrrfo\",\"wording\":\"Send honest messages\"}";
                    streamWriter.Write(json);
                    Console.WriteLine(json);
                }
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                sentCount++;
                Thread.Sleep(1000);
                sendRequest();
            }
            Console.WriteLine("ID: ");
            yoloID = Console.ReadLine();
            Console.WriteLine("Response: ");
            textToSend = Console.ReadLine();
            Console.WriteLine("How many: ");
            maxCount = Convert.ToInt32(Console.ReadLine());
            sendRequest();
            Console.WriteLine("Message sent: " + textToSend + "\nID: " + yoloID + "\nRequests sent: " + maxCount);
        }
    }
}
