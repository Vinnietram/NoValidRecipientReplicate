using System;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using FakeSmtpClient;
using MimeKit;

namespace SmtpClientApp
{
    class Program
    {
        private static IMailKitSmtpClient _fakeSmtpClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Press F1 to start sending messages");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.F1))
            {

            }

            CreateSmtpClient();

            Timer smtpClientSendTimer = new Timer(SendMessageToServerEveryInterval, "", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            Thread.Sleep(Timeout.Infinite);
        }

        private static void SendMessageToServerEveryInterval(object state)
        {
            if (_fakeSmtpClient.IsConnected())
            {
                var mailMessage = CreateMailMessage();
                _fakeSmtpClient.Send(MimeMessage.CreateFromMailMessage(mailMessage),
                    new MailboxAddress(mailMessage.From.User, mailMessage.From.Address),
                    new[] {new MailboxAddress(mailMessage.To.First().User, mailMessage.To.First().Address)});
            }
        }

        private static void CreateSmtpClient()
        {
            var fakeSmtpClientFactory = new MailkitSmtpClientFactory();
            _fakeSmtpClient = fakeSmtpClientFactory.Create();
            _fakeSmtpClient.Connect("localhost", 50000);
        }

        private static MailMessage CreateMailMessage()
        {
            var mailMessage = new MailMessage { From = new MailAddress("tom@mail.localhost.com") };
            mailMessage.To.Add("dick@mail.localhost.com");
            mailMessage.Subject = "Test Subject";
            mailMessage.Body = "Test Body";
            mailMessage.IsBodyHtml = false;

            return mailMessage;
        }
    }
}
