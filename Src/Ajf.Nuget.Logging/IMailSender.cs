using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Ajf.Nuget.Logging
{
    public interface IMailSender
    {
        Task<HttpStatusCode> SendMailAsync(string toAddress, string ccAddress, string senderAddress, string subject, string bodyAsHtml, IEnumerable<string> attachmentPaths);
    }
}