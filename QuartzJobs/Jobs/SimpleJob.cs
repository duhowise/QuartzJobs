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
            var dataMap = context.MergedJobDataMap;
            var username = dataMap.GetString("username");
            var password = dataMap.GetString("password");
            var triggerData = dataMap.GetString("triggerParam");
            var user = dataMap.Get("user") as SimpleJobParameter;
            Debug.WriteLine($"{triggerData} trigger data");
            Debug.WriteLine($"{username} Username");
            Debug.WriteLine($"{password} Password");
            Debug.WriteLine($"{nameof(SimpleJob)} Executed");
            await _emailSender.SendEmailAsync("some@email.com", "DI", "DI works");
        }
    }
}