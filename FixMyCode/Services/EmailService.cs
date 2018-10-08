using Microsoft.Extensions.Configuration;
using SendGrid.SmtpApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FixMyCode.Services
{
    public class EmailService : IEmailService
    {

        IConfiguration configuration;

        public EmailService(IConfiguration config)
        {
            configuration = config;
        }

        public void EmailStudent(string emailAddress)
        {

            var header = new Header();

            var uniqueArgs = new Dictionary<string, string> { {"authorization", $"{configuration.GetValue<string>("SMTP:password")}"} };

            header.AddUniqueArgs(uniqueArgs);

            var xmstpapiJson = header.JsonString();

            SmtpClient client = new SmtpClient
            {
                Port = configuration.GetValue<int>("STMP:port"),
                Host = "smtp.sendgrid.net",
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("fixmycode", "fixmycodeteam2018")
            };

            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(emailAddress));
            mail.From = new MailAddress("no-reply@fixmycode.net");
            mail.Subject = "Hi Elijah!";
            mail.Body = "this is my test email body";

            // add the custom header that we built above
            mail.Headers.Add("X-SMTPAPI", xmstpapiJson);

            client.SendAsync(mail, null);
        }

        public void VerifyEmail(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
