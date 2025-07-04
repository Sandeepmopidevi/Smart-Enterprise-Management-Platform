using SmartEnterprise.NotificationService.Models;
using System.Net;
using System.Net.Mail;

namespace SmartEnterprise.NotificationService.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(EmailRequest request)
        {
            var smtpClient = new SmtpClient(_config["Smtp:Host"])
            {
                Port = int.Parse(_config["Smtp:Port"]),
                Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_config["Smtp:Username"]),
                Subject = request.Subject,
                Body = request.Body,
                IsBodyHtml = true
            };

            mail.To.Add(request.ToEmail);

            await smtpClient.SendMailAsync(mail);
        }
    }
}
