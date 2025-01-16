using Hangfire;
using Hangfire.Dashboard;
using Library.Application;
using Library.Application.Jobs;
using Library.Application.Services;
using Library.Core.ServicesInterfaces;
using Library.Infrastructure;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
});

ConfigureHangfireJobs(app);

app.MapControllers();

app.Run();


void ConfigureHangfireJobs(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var jobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

        RecurringJobsConfiguration.ConfigureRecurringJobs(jobManager, emailService);
    }
}

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true; 
    }
}