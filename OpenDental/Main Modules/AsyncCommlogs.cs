﻿using OpenDentBusiness;
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
                
                var response = await sharedClient.GetAsync(send);
                var text = await response.Content.ReadAsStringAsync();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(text);
                var list = xmlDoc.ChildNodes[1];
                foreach (XmlElement child in list.ChildNodes)
                {
                    string from = child.ChildNodes[0].InnerText;
                    Console.WriteLine(from);
                    string msgText = child.ChildNodes[2].InnerText;
                    Console.WriteLine(msgText);
                    string msgTime = child.ChildNodes[11].InnerText;
                    var time = DateTime.Parse(msgTime);
                    Console.WriteLine(msgText);
                    var patients = Patients.GetPatientsByPhone(from.Substring(3), "+64");
                    Console.WriteLine(patients.Count);
                    Commlog log = new Commlog();
                    if (patients.Count != 0)
                    {
                        log.PatNum = patients[0].PatNum;
                    }
                    log.Note = "Text message received: " + msgText;
                    log.Mode_ = CommItemMode.Text;
                    log.CommDateTime = time;
                    Commlogs.Insert(log);
                }
               
/*                }
                catch
                {
                    MsgBox.Show("Receiving patient texts failed.");
                }*/
              
            }
        }
    }
}
