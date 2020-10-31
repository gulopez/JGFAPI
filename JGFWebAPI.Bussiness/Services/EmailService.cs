using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;
using System;

namespace JGFWebAPI.Bussiness.Services
{
    //public static class Constants
    //{
      
    //}

    public class EmailService
    {
        private  string SENDERNAME = "Colegio Jose Gil Fortoul";
        private string SENDEREMAIL = "institutojosegilfortoul@gmail.com";

        //Send Grid
        private string SMTPHOST = "smtp.sendgrid.net";
        private string SMTPUSERNAME = "";
        private string SMTPUSERPASSWORD = "";
        private int SMTPPORT = 465;
        public EmailService()
        {
            //Send Grid       
            SMTPUSERNAME = Environment.GetEnvironmentVariable("SENDGRID_API_USER");
            SMTPUSERPASSWORD = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            
        }
        public Task SendEmailAsync(string recipientEmail, string subject, string message)
        {
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(SENDERNAME, SENDEREMAIL));
            mimeMessage.To.Add(new MailboxAddress("", recipientEmail));
            mimeMessage.Subject = subject;

            mimeMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = message,
            };

            using (var client = new SmtpClient())
            {

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(SMTPHOST, SMTPPORT, true);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(SMTPUSERNAME, SMTPUSERPASSWORD);

                client.Send(mimeMessage);

                client.Disconnect(true);
                return Task.FromResult(0);
            }
        }
    }
}
