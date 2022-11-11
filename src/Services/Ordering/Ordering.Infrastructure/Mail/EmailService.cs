using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailService(IOptions<EmailSettings> emailSettingsty, ILogger<EmailService> logger)
        {
            _emailSettingsty = emailSettingsty.Value ?? throw new ArgumentNullException(nameof(emailSettingsty));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public EmailSettings _emailSettingsty { get; }

        public ILogger<EmailService> _logger { get; }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettingsty.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddressAttribute
            {
                //Email = _emailSettingsty.FromAddress,
                //Name = _emailSettingsty.FromName
            };

            return false;


        }
    }
}
