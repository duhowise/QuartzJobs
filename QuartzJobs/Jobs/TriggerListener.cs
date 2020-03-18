using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace QuartzJobs.Jobs
{
    public class TriggerListener:ITriggerListener
    {
        public Task TriggerFired(ITrigger trigger, IJobExecutionContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"Trigger fired: {trigger.Key.Name}");

            return Task.CompletedTask;
        }

        public Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(false);
        }

        public Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = new CancellationToken())
        {
            Debug.WriteLine($"Trigger misfired: {trigger.Key.Name}");

          return Task.CompletedTask;
        }

        public Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode,
            CancellationToken cancellationToken = new CancellationToken())
        {
          Debug.WriteLine($"Trigger Completed: {trigger.Key.Name}");
          return Task.CompletedTask;
        }

        public string Name => "Test trigger Listener";
    }
}