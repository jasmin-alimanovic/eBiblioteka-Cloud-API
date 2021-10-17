using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    public interface IMailSender
    {
        Task SendPlainTextEmailAsync(string recipientEmail, string recipientName);
        Task SendHtmlEmailAsync(string recipientEmail, string recipientName);
        Task SendHtmlWithAttachmentEmailAsync(string recipientEmail, string recipientName);

    }
}
