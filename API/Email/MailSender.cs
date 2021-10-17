using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    public class MailSender : IMailSender
    {
        private readonly IServiceProvider _serviceProvider;

        public MailSender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task SendHtmlEmailAsync(string recipientEmail, string recipientName)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var email = mailer
                .To(recipientEmail, recipientName)
                .Subject($"Hello {recipientName}")
                .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/templates/RegisterTemplateEmail.cshtml",
                new
                {
                    Ime = recipientName,
                }
                );
                await email.SendAsync();
            }
        }

        public Task SendHtmlWithAttachmentEmailAsync(string recipientEmail, string recipientName)
        {
            throw new NotImplementedException();
        }

        public async Task SendPlainTextEmailAsync(string recipientEmail, string recipientName)
        {
            
            using (var scope = _serviceProvider.CreateScope())
            {
                var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var email = mailer
                .To(recipientEmail, recipientName)
                .Subject($"Hello {recipientName}")
                .Body("You are now successfully registered on E-Biblioteka Cloud");
                await email.SendAsync();
            }
        }
    }
}
