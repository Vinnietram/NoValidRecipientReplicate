using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReplicateScenario
{
    class Program
    {
        static void Main(string[] args)
        {
            LaunchSmtpServer();
            LaunchSmtpClient();
        }

        private static void LaunchSmtpServer()
        {
            var smtpServer = new Process
            {
                StartInfo =
                {
                    FileName = @"..\..\..\SmtpServerApp\bin\Debug\SmtpServerApp.exe",
                    Arguments = "-v -s -a"
                }
            };
            smtpServer.Start();
        }

        private static void LaunchSmtpClient()
        {
            var smtpClient = new Process
            {
                StartInfo =
                {
                    FileName = @"..\..\..\SmtpClientApp\bin\Debug\SmtpClientApp.exe",
                    Arguments = "-v -s -a"
                }
            };
            smtpClient.Start();
        }
    }
}
