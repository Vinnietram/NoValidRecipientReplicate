using System;
using System.Collections.Generic;
using MimeKit;

namespace FakeSmtpClient
{
    public interface IMailKitSmtpClient : IDisposable
    {
        void Connect(string host, int port);

        bool IsConnected();

        void Send(MimeMessage mimeMessage, MailboxAddress sender,
            IEnumerable<MailboxAddress> recipients);
    }
}