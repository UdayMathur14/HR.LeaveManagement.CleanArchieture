using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Logging;
using HR.LeaveManagement.Application.Models.Email;
using HR.LeaveManagement.Infrastructure.EmailService;
using HR.LeaveManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;

namespace HR.LeaveManagement.Infrastructure
{
    

        //logging = allow us to track and trace errors that occur in our application 
        //: there are different levels so it is importnat to understand them 
        //1 Information :standard log level used when something has happended as expected 
        //2:Debug : a very information log level that is more than we might need for everyday use 
        //3 :Warning : this log indicates that something has happended that isn't an error but isn't normal 
        //4 : Error - An error is an error . This typeof of log entry is usually created when an exception is encountered

        public static class InfrastructureServicesRegistration
        {
            public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
            {
                services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
                services.AddTransient<IEmailSender, EmailSender>();
                services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
                return services;
            }
        }

    }
    
