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
            return builder.HtmlBody;
        }
        private string FillVerificationTemplate(User user)
        {
            var path = _env.ContentRootPath +
                        Path.DirectorySeparatorChar.ToString() +
                        "wwwroot" +
                        Path.DirectorySeparatorChar.ToString() +
                        "emails" +
                        Path.DirectorySeparatorChar.ToString() +
                        "VerificationEmail.html";
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = File.OpenText(path))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            builder.HtmlBody = builder.HtmlBody.Replace("{1}", "https://localhost:7199/User/Verify?token=" + user.VerificationToken);
            return builder.HtmlBody;
        }
        
        private string FillPaswordResetTemplate(User user)
        {
            var path = _env.ContentRootPath +
                        Path.DirectorySeparatorChar.ToString() +
                        "wwwroot" +
                        Path.DirectorySeparatorChar.ToString() +
                        "emails" +
                        Path.DirectorySeparatorChar.ToString() +
                        "ResetPasswordEmail.html";
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = File.OpenText(path))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            builder.HtmlBody = builder.HtmlBody.Replace("{1}", "https://localhost:7199/User/ResetPassword?token=" + user.PasswordResetToken);
            return builder.HtmlBody;
        }

        private void SendEmailAsync(MimeMessage emailRequest)
        {
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_mailgun.HostName, _mailgun.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailgun.Username, _mailgun.Password);
            smtp.Send(emailRequest);
            smtp.Disconnect(true);
        }


        public void SendContactEmail(Email email)
        {
            var emailRequest = new MimeMessage();
            emailRequest.From.Add(MailboxAddress.Parse(_mailgun.Sender));
            emailRequest.To.Add(MailboxAddress.Parse(_mailgun.Reciever));
            emailRequest.Subject = "Novi upit na Rotary Sarajevo web stranici";
            emailRequest.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = FillTemplate(email) };
            SendEmailAsync(emailRequest);
        }

        public void SendVerificationEmail(User user)
        {
            var emailRequest = new MimeMessage();
            emailRequest.From.Add(MailboxAddress.Parse(_mailgun.Sender));
            emailRequest.To.Add(MailboxAddress.Parse(user.Email));
            emailRequest.Subject = "Verifikujte vaš račun na Rotary Sarajevo";
            emailRequest.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = FillVerificationTemplate(user) };
            SendEmailAsync(emailRequest);
        }
        
        public void SendPasswordResetEmail(User user)
        {
            var emailRequest = new MimeMessage();
            emailRequest.From.Add(MailboxAddress.Parse(_mailgun.Sender));
            emailRequest.To.Add(MailboxAddress.Parse(user.Email));
            emailRequest.Subject = "Resetujte vašu lozinku na Rotary Sarajevo";
            emailRequest.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = FillPaswordResetTemplate(user) };
            SendEmailAsync(emailRequest);
        }
    }
}