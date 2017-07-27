using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;

namespace Ajf.Nuget.Logging
{
    public class MailSender : IMailSender
    {
        public async Task<HttpStatusCode> SendMailAsync(string toAddress, string ccAddress, string senderAddress,
            string subject, string bodyAsHtml, IEnumerable<string> attachmentPaths)
        {
            Log.Logger.Information("SendMailAsync-");

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_KEY");
            Debug.WriteLine(apiKey);
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(senderAddress);

            var to = new EmailAddress(toAddress);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "Read as html", bodyAsHtml);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            return response.StatusCode;
        }
    }
}