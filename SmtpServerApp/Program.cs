using System;
using System.Threading;

namespace SmtpServerApp
{
    class Program
    {
        private static FakeSmtpServer.FakeSmtpServer _fakeSmtpServer;

        static void Main(string[] args)
        {
            StartFakeSmtpServer();

            Console.WriteLine("Press F1 to keep restarting SMTP server");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.F1))
            {
            }

            Timer restartSmtpServertimer = new Timer(RestartFakeSmtpServer, "", TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(2));

            Thread.Sleep(Timeout.Infinite);
        }

        private static void StartFakeSmtpServer()
        {
            _fakeSmtpServer = new FakeSmtpServer.FakeSmtpServer();
            _fakeSmtpServer.StartServer().GetAwaiter();
        }

        private static void RestartFakeSmtpServer(object state)
        {
            _fakeSmtpServer.StopServer();
            StartFakeSmtpServer();
        }
    }
}
