using System.Net;
using NUnit.Framework;

namespace Ajf.Nuget.Logging.Tests
{
    [TestFixture]
    public class MailSenderTests
    {
        [Test]
        public void TestThatMailCanBeSend()
        {
            var mailSender = new MailSender();
            var httpStatusCode = mailSender.SendMailAsync("andersjuulsfirma@gmail.com", "andersjuulsfirma@gmail.com",
                "andersjuulsfirma@gmail.com", "Subject", "<html><html>", new string[] { }).Result;

            Assert.AreEqual(HttpStatusCode.Accepted, httpStatusCode);
        }
    }
}