using FixMyCode.Entities;
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

        public EmailService(IConfiguration configuration)
        {
            config = configuration;
        }

        public async void EmailStudent(string emailAddress)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@fixmycode.net");
            var subject = "test subject";
            var to = new EmailAddress("elijahboucharddrhs@gmail.com");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            
        }

        public async void VerifyEmail(AppUser user, string callbackUrl, string userType)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@fixmycode.net");
            var subject = "Verify Email";
            var to = new EmailAddress(user.Email);
            var plainTextContent = "";
            var htmlContent = $"Please confirm your account by clicking this link: {callbackUrl}";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
