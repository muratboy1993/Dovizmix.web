using System.Collections.Generic;

namespace Infrastructure.Utility.Abstract
{
    public interface IMailSender
    {
        void Send(List<string> email, string body, string subject);
        void Send(string email, string body, string subject);
    }
}
