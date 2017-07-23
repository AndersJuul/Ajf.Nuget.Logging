﻿using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;

namespace Ajf.Nuget.Logging
{
    public class MailSender: IMailSender
    {
        public async Task SendMailAsync(string toAddress, string ccAddress, string senderAddress, string subject, string bodyAsHtml)
        {
            //var folderContents = GetFolderContents(path, path).ToArray();
            
            var fromMailAddress = new MailAddress(senderAddress);
            var networkCredential = new NetworkCredential("azure_9ce305d9c6ab84b3d5fb7723deca51f5@azure.com",
                "6oi3vEdJl5GldVc");
            var transport = new Web(networkCredential);

            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage
            {
                From = fromMailAddress
            };

            myMessage.AddTo(toAddress);
            myMessage.AddCc(ccAddress);

            var bytes = Encoding.Default.GetBytes(subject);
            myMessage.Subject = Encoding.UTF8.GetString(bytes);
            myMessage.Html = bodyAsHtml;

            // Send the email.
            await transport.DeliverAsync(myMessage);
        }
    }
}