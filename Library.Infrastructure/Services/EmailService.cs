using Library.Core.ServicesInterfaces;

namespace Library.Infrastructure.Services;
public class EmailService : IEmailService
{
    public Task<bool> SendEmail(string recipient, string text)
    {
        return Task.FromResult(true);
    }
}
