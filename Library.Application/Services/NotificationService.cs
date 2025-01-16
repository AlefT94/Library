using Library.Core.ServicesInterfaces;

namespace Library.Application.Services;
public class NotificationService(ILoanRepository loanRepository)
{
    public async Task NotifyOverdueBooksAsync(IEmailService emailService)
    {
        var overdueLoans = await loanRepository.GetOverdueLoansAsync();

        overdueLoans.ForEach(async loan =>
        {
            Console.WriteLine($"Overdue Book Notifications: {loan.Book.Title}");
            await emailService.SendEmail("test@gmail.com", $"Overdue Book Notifications: {loan.Book.Title}");
        });
    }
}
