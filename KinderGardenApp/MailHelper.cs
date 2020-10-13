using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace KinderGardenApp
{


    public class MailHelper
    {
        public IConfiguration Configuration { get; }

        public MailHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void SendApplicationReceived(string email, string to)
        {
            string message = "Почитувани,\n Вашата апликација е успешно примена.\n\nСо почит,\nМајски Цвет";
            string subject = "Апликација";

            SentEmail(email, to, message, subject, null);

        } 
        public void SendApplicationApproved(string email, string to)
        {
            string message = "Почитувани,\n Вашата апликација е одобрена.\n\nВо прилог Ви праќаме комлетна документација.\n\nЗа повеќе информации обратете се на 02/3086-097.\n\nСо почит,\nМајски Цвет";
            string subject = "Апликација";

            List<Attachment> attachments = new List<Attachment>();
            Attachment attachment = new Attachment("File\\ДОГОВОР ЗА ДЕТЕ -НОВ.doc");
            attachments.Add(attachment);
            attachment = new Attachment("File\\ПРИЈАВА ЗА ДЕТЕ - 2019.docx");
            attachments.Add(attachment);

            SentEmail(email, to, message, subject, attachments);


        }
        public void SendApplicationDenied(string email, string to)
        {
            string message = "Почитувани,\n Вашата апликација е одбиена.\nЗа повеќе информации обратете се на 02/3086-097.\n\nСо почит,\nМајски Цвет";
            string subject = "Апликација";
            SentEmail(email, to, message, subject, null);
        }
        
        private void SentEmail(string toEmail, string toName, string messageTxt, string subject, List<Attachment> attachments)
        {
            string from = Configuration.GetSection("MailSettings").GetSection("Email").Value;
            string fromName = Configuration.GetSection("MailSettings").GetSection("From").Value;
            string fromPassword = Configuration.GetSection("MailSettings").GetSection("Password").Value;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, fromPassword)
            };

            MailAddress fromEmail = new MailAddress(from, fromName);

            MailMessage mail = new MailMessage();

            mail.From = fromEmail;
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = messageTxt;

            if (attachments != null) {
                foreach (var attach in attachments)
                {
                    mail.Attachments.Add(attach);
                }
            }

            smtp.Send(mail);
        }
    }
}
