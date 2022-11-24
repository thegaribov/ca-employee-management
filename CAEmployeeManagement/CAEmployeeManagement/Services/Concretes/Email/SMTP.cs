using CAEmployeeManagement.Services.Abstracts;
using System.Diagnostics;

namespace CAEmployeeManagement.Services.Concretes.Email
{
    public class SMTP : IEmailService
    {
        public void SendBulk(string from, string[] tos, string message)
        {
            //
        }

        public void SendIndividual(string from, string to, string message)
        {
            //
        }


    }
}
