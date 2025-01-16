namespace Library.Core.ServicesInterfaces;
public interface IEmailService
{
    Task<bool> SendEmail(string recipient, string text);
}
