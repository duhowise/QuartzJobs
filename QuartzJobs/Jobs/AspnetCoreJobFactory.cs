using System;
using Quartz;
using Quartz.Simpl;
using Quartz.Spi;

namespace QuartzJobs.Jobs
{
    public class AspnetCoreJobFactory:SimpleJobFactory
    {
        private readonly IServiceProvider _provider;

        public AspnetCoreJobFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return (IJob)_provider.GetService(bundle.JobDetail.JobType);

            }
            catch (Exception e)
            {
               throw new SchedulerException($"problem occured while instantiating job {bundle.JobDetail.Key} from the aspnet core job factory");
            }
        }
    }
}