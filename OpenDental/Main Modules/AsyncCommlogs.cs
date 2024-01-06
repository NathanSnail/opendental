using OpenDentBusiness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;
using Task = System.Threading.Tasks.Task;

namespace OpenDental.Main_Modules
{
    internal static class AsyncCommlogs
    {
        private static HttpClient sharedClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:9710/"),
        };
        private static string auth = null;

        async public static void Test()
        {
            if (auth == null)
            {
                foreach (string line in File.ReadLines("./auth"))
                {
                    if (line.Contains("&"))
                    {
                        auth = line;
                    }
                }
            }
            string send = "http/request-received-messages?&" + auth;
            while (true) {
               
                /*try
                {*/
                await Task.Delay(10 * 1000); // this is at start because there are race conditions i don't want to fix. We need to wait for init to be done before we can use comlogs
                Console.WriteLine("!!");
                Commlog log = new Commlog();
                log.Note = "hello!";
                var response = await sharedClient.GetAsync(send);
                var text = await response.Content.ReadAsStringAsync();
                Console.WriteLine(text);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(text);
                var list = xmlDoc.ChildNodes[1];
                Console.WriteLine(list.InnerText);
                foreach (XmlElement child in list.ChildNodes)
                {
                    Console.WriteLine(child.InnerText);
                    string from = child.GetAttribute("From");
                    Console.WriteLine(from);
                }
                log.PatNum = 22;
                Commlogs.Insert(log);
/*                }
                catch
                {
                    MsgBox.Show("Receiving patient texts failed.");
                }*/
              
            }
        }
    }
}
