using CAEmployeeManagement.Services.Abstracts;
using System.Diagnostics;

namespace CAEmployeeManagement.Services.Concretes.Email
{
    public class SendGrid : IEmailService
    {
        public void SendIndividual(string from, string to, string message)
        {
            // body implementation
        }

        public void SendBulk(string from, string[] tos, string message)
        {
            // body implementation
        }
    }
}
