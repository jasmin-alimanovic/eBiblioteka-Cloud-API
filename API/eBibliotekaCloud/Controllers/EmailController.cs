using Email;
using FluentEmail.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailSender _mailSender;
        public EmailController(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        [HttpPost("send-plain-text-email")]
        public async Task<IActionResult> SendPlainTextEmailAsync()
        {
            await _mailSender.SendPlainTextEmailAsync("jasko.alimanovic@gmail.com", "Jasmin Alimanovic");
            return Ok("Success");
        }
        [HttpGet("send-html-email")]
        public async Task<IActionResult> SendHtmlEmailAsync()
        {
            await _mailSender.SendHtmlEmailAsync("jasko.alimanovic@gmail.com", "Jasmin Alimanovic");
            return Ok("Success");
        }
    }
}
