using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace QuartzJobs.Jobs
{
    public class JobListener:IJobListener
    {
        public string Name =>"Job Listener";

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"Job Executed: {context.JobDetail.Key.Name}");
            return Task.CompletedTask;
        }

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"Job vetoed: {context.JobDetail.Key.Name}");
            return Task.CompletedTask;
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException,
            CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"Job Executed: {context.JobDetail.Key.Name}");
            return Task.CompletedTask;
        }

    }
}