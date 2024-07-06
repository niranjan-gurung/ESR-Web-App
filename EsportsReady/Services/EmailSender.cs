using EsportsReady.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace EsportsReady.Data
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                           ILogger<EmailSender> logger)
        {
            Options = optionsAccessor.Value;
            _logger = logger;
        }

        public AuthMessageSenderOptions Options { get; }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }

            var client = new SendGridClient(Options.SendGridKey);
            var msg = new SendGridMessage()
            {
                // "gurung5130@gmail.com" == temp domain setup on sendgrid,
                // all emails are sent from this domain for the time being..
                // needs to be replaced with real domain/host.
                From = new EmailAddress("gurung5130@gmail.com", "Esports Ready"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);

            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }
    }
}
