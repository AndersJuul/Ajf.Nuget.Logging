using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ajf.Nuget.Logging
{
    public interface IMailSender
    {
        Task SendMailAsync(string toAddress, string ccAddress, string senderAddress, string subject, string bodyAsHtml, IEnumerable<string> attachmentPaths);
    }
}