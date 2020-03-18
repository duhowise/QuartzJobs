using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Quartz;

namespace QuartzJobs.Jobs
{
    public class SimpleJob : IJob
    {
        private readonly IEmailSender _emailSender;

        public SimpleJob(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _emailSender.SendEmailAsync("some@email.com", "DI", "DI works");
        }
    }
}