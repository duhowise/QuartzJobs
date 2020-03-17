using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using QuartzJobs.Jobs;

namespace QuartzJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IScheduler _scheduler;

        public JobsController(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
      [Route("")][HttpPost]  public async Task<IActionResult> StartSimpleJob()
        {
            var simpleJobDetail  = JobBuilder.Create<SimpleJob>().UsingJobData("username","some data").UsingJobData("password","somePass").WithIdentity(nameof(SimpleJob), "Jobs").StoreDurably().Build();
            simpleJobDetail.JobDataMap.Put("user", new SimpleJobParameter
            {
                Username = "NiceOne",
                Password = "NiceOne"

            });

            await _scheduler.AddJob(simpleJobDetail, true);

            var trigger = TriggerBuilder.Create()
                .ForJob(simpleJobDetail)
                .UsingJobData("triggerParam","sample trigger data")
                .WithIdentity($"{nameof(SimpleJob)}Trigger", "Jobs")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).WithRepeatCount(5)).Build();
            
            
            var trigger2 = TriggerBuilder.Create()
                .ForJob(simpleJobDetail)
                .UsingJobData("triggerParam", "sample trigger2 data")
                .WithIdentity($"{nameof(SimpleJob)}Trigger2", "Jobs")
                .StartNow()
                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(5)).RepeatForever()).Build();
          
            
            
            
            
            await _scheduler.ScheduleJob(trigger);
            await _scheduler.ScheduleJob(trigger2);
            return Ok(simpleJobDetail);
        }
    }
}