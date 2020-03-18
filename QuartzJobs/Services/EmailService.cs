using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace QuartzJobs.Services
{
    public class EmailService:IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Debug.WriteLine($"Sending email to {email} with subject {subject} and body {htmlMessage}");
            return  Task.CompletedTask;
        }
    }
}