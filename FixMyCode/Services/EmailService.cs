using FixMyCode.Configauration_POCO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.SmtpApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FixMyCode.Services
{
    public class EmailService : IEmailService
    {

        public IConfiguration config;
        private readonly SMTP smtp;

        public EmailService(IConfiguration configuration, IOptions<SMTP> myConfiguration)
        {
            config = configuration;
            smtp = myConfiguration.Value;
        }

        public async void EmailStudent(string emailAddress)
        {
            var apiKey = smtp.ApiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@fixmycode.net");
            var subject = "test subject";
            var to = new EmailAddress("elijahboucharddrhs@gmail.com");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            
        }

        public void VerifyEmail(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
