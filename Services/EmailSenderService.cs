using Microsoft.Extensions.Options;
using MimeKit;
using RotaryClub.Data.Settings;
using RotaryClub.Interfaces;
using RotaryClub.Models;

namespace RotaryClub.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IHostEnvironment _env;
        private readonly MailgunSettings _mailgun;
        public EmailSenderService(IHostEnvironment env, IOptions<MailgunSettings> mailgun)
        {
            _mailgun = mailgun.Value;
            _env = env;
        }

        private string FillTemplate(Email email)
        {
            var path = _env.ContentRootPath +
                        Path.DirectorySeparatorChar.ToString() +
                        "wwwroot" +
                        Path.DirectorySeparatorChar.ToString() +
                        "emails" +
                        Path.DirectorySeparatorChar.ToString() +
                        "ContactFormEmail.html";
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(path))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            builder.HtmlBody = builder.HtmlBody.Replace("{0}", email.Name);
            builder.HtmlBody = builder.HtmlBody.Replace("{1}", email.Lastname);
            builder.HtmlBody = builder.HtmlBody.Replace("{2}", email.EmailAddress);
            builder.HtmlBody = builder.HtmlBody.Replace("{3}", email.PhoneNumber);
            builder.HtmlBody = builder.HtmlBody.Replace("{4}", email.Message);
            builder.HtmlBody = builder.HtmlBody.Replace("{5}", email.EmailAddress);
            return builder.HtmlBody;
        }

        public void SendContactEmail(Email email)
        {
            var emailRequest = new MimeMessage();
            emailRequest.From.Add(MailboxAddress.Parse(_mailgun.Sender));
            emailRequest.To.Add(MailboxAddress.Parse(_mailgun.Reciever));
            emailRequest.Subject = "Novi upit na FINIT web stranici";
            emailRequest.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = FillTemplate(email) };
            SendEmailAsync(emailRequest);
        }

        public void SendVerificationEmail(Email email)
        {
            var emailRequest = new MimeMessage();
            emailRequest.From.Add(MailboxAddress.Parse(_mailgun.Sender));
            emailRequest.To.Add(MailboxAddress.Parse(email.EmailAddress));
            emailRequest.Subject = "Verifikujte vaš račun na Rotary Sarajevo";
            emailRequest.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = FillTemplate(email) };
            SendEmailAsync(emailRequest);
        }
        private void SendEmailAsync(MimeMessage emailRequest)
        {
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_mailgun.HostName, _mailgun.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailgun.Username, _mailgun.Password);
            smtp.Send(emailRequest);
            smtp.Disconnect(true);
        }
    }
}
