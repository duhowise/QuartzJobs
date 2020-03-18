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
            //save the job
            await _scheduler.AddJob(simpleJobDetail, true);

          
            
            
            var trigger2 = TriggerBuilder.Create()
                .ForJob(simpleJobDetail)
                .UsingJobData("triggerParam", "sample trigger2 data")
                .WithIdentity($"{nameof(SimpleJob)}Trigger2", "Jobs")
                .StartNow()
                .WithCronSchedule("0 0/1 * 1/1 * ? *")
                .Build();
          
            
            
            
            
            await _scheduler.ScheduleJob(trigger2);
            return Ok(simpleJobDetail);
        }
    }
}