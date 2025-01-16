using Hangfire;
using Library.Application.Services;
using Library.Core.ServicesInterfaces;

namespace Library.Application.Jobs;
public static class RecurringJobsConfiguration
{
    public static void ConfigureRecurringJobs(IRecurringJobManager recurringJobManager, IEmailService emailService)
    {
        recurringJobManager.AddOrUpdate<NotificationService>(
            "notify-overdue-books",
            service => service.NotifyOverdueBooksAsync(emailService),
            "1 0 * * *"
        );

    }
}
