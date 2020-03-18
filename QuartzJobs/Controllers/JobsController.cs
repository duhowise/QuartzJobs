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




            ITrigger trigger = TriggerBuilder.Create()
                .ForJob(simpleJobDetail)
                .UsingJobData("triggerparam", "Simple trigger 1 Parameter")
                .WithIdentity("testtrigger", "Jobs")
                .StartNow()
                .WithSimpleSchedule(z => z.WithIntervalInSeconds(5).RepeatForever())
                .Build();

            await _scheduler.ScheduleJob(trigger);
            return Ok(simpleJobDetail);
        }
    }
}