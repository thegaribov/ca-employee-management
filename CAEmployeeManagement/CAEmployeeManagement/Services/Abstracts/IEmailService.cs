namespace CAEmployeeManagement.Services.Abstracts
{
    public interface IEmailService
    {
        void SendIndividual(string from, string to, string message);
        void SendBulk(string from, string[] tos, string message);
    }
}
