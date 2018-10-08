using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FixMyCode.Models
{
    public class EmailMessage
    {
        /*Subject line of the email*/
        public string Subject { get; set; }
        /*The body of the email*/
        public string Body { get; set; }
        /**/
        public string Address { get; set; }

        /**/
        public MailMessage FormatCompletedMessageForStudent()
        {
            return new MailMessage();
        }

        /**/
        public MailMessage FormatConfirmEmailMessage()
        {
            return new MailMessage();
        }

        

    }
}
