using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;

namespace Ajf.Nuget.Logging
{
    public class MailSender: IMailSender
    {
        public async Task<HttpStatusCode> SendMailAsync(string toAddress, string ccAddress, string senderAddress, string subject, string bodyAsHtml, IEnumerable<string> attachmentPaths)
        {
            Log.Logger.Information("SendMailAsync-");

            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(senderAddress, "Sender");

            var to = new EmailAddress(toAddress, "Example User");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "Read as html", bodyAsHtml);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            return response.StatusCode;
        }
    }
}