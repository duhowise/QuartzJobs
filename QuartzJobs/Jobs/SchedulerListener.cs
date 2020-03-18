using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace QuartzJobs.Jobs
{
    public class SchedulerListener:ISchedulerListener
    {
        public string Name =>"Test Scheduler Listener";


        public Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"trigger added: {trigger.Key.Name}");
            return Task.CompletedTask;
        }

        public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"trigger schedules: {triggerKey.Name}");
            return Task.CompletedTask;
        }

        public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"trigger finalized: {trigger.Key.Name}");
            return Task.CompletedTask;
        }

        public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"trigger paused: {triggerKey.Name}");
            return Task.CompletedTask;
        }

        public Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"trigger resumed: {triggerKey.Name}");
            return Task.CompletedTask;
        }

        public Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"triggers resumed: ");
            return Task.CompletedTask;
        }

        public Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"job added: {jobDetail.Key.Name}");
            return Task.CompletedTask;
        }

        public Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"job deleted: {jobKey.Name}");
            return Task.CompletedTask;
        }

        public Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"job paused: {jobKey.Name}");
            return Task.CompletedTask;
        }

        public Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"job interrupted: {jobKey.Name}");
            return Task.CompletedTask;
        }

        public Task JobsPaused(string jobGroup, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"jobs paused: ");
            return Task.CompletedTask;
        }

        public Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"job resumed: {jobKey.Name}");
            return Task.CompletedTask;
        }

        public Task JobsResumed(string jobGroup, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"jobs resumed:");
            return Task.CompletedTask;
        }

        public Task SchedulerError(string msg, SchedulerException cause,
            CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"error occured: {msg}");
            return Task.CompletedTask;
        }

        public Task SchedulerInStandbyMode(CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"scheduler in standby mode:");
            return Task.CompletedTask;
        }

        public Task SchedulerStarted(CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"scheduler started");
            return Task.CompletedTask;
        }

        public Task SchedulerStarting(CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"scheduler starting");
            return Task.CompletedTask;
        }

        public Task SchedulerShutdown(CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"scheduler shutdown");
            return Task.CompletedTask;
        }

        public Task SchedulerShuttingdown(CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"scheduler shutting down");
            return Task.CompletedTask;
        }

        public Task SchedulingDataCleared(CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"scheduler clear");
            return Task.CompletedTask;
        }
    }
}