using System.Diagnostics;
using System.Threading.Tasks;
using Quartz;

namespace QuartzJobs.Jobs
{
    public class SimpleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
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
            return Task.CompletedTask;
        }
    }
}