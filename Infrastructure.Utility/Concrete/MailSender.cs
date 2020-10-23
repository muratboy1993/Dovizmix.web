using System.Net.Mail;
using Infrastructure.Utility.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Collections.Generic;

namespace Infrastructure.Utility.Concrete
{
    public class MailSender : IMailSender
    {
        private readonly IConfiguration _config;

        public MailSender(IConfiguration config)
        {
            _config = config;
        }

        public void Send(List<string> email, string body, string subject)
        {
            string from = _config.GetValue<string>("MailSender:Email"); //From address
            string displayName = _config.GetValue<string>("MailSender:DisplayName");
            MailMessage message = new MailMessage
            {
                From = new MailAddress(from, displayName)
            };

            message.Subject = subject;
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(_config.GetValue<string>("MailSender:Email"), _config.GetValue<string>("MailSender:Password"));
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            //Todo : Kaan attachment eklenecek.

            foreach (string multiple_email in email)
            {
                message.To.Add(new MailAddress(multiple_email));
                try
                {
                    client.Send(message);
                    message.To.Clear();
                }

                catch (Exception ex)
                {
                    throw ex;
                    //Todo : Moboy loglama
                }
            }
        }

        public void Send(string email, string body, string subject)
        {
            string from = _config.GetValue<string>("MailSender:Email"); //From address
            string displayName = _config.GetValue<string>("MailSender:DisplayName");
            MailMessage message = new MailMessage
            {
                From = new MailAddress(from, displayName)
            };

            message.Subject = subject;
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(_config.GetValue<string>("MailSender:Email"), _config.GetValue<string>("MailSender:Password"));
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            //Todo : Kaan attachment eklenecek.

            message.To.Add(new MailAddress(email));
            try
            {
                client.Send(message);
                message.To.Clear();
            }

            catch (Exception ex)
            {
                throw ex;
                //Todo : Moboy loglama
            }
        }
    }
}
