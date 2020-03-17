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
            var simpleJobDetail  = JobBuilder.Create<SimpleJob>().UsingJobData("username","some data").UsingJobData("password","somePass").WithIdentity(nameof(SimpleJob), "Jobs").Build();
            simpleJobDetail.JobDataMap.Put("user", new SimpleJobParameter
            {
                Username = "NiceOne",
                Password = "NiceOne"

            });
            var trigger = TriggerBuilder.Create().UsingJobData("triggerParam","sample trigger data").WithIdentity($"{nameof(SimpleJob)}Trigger", "Jobs").StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).WithRepeatCount(5)).Build();
            await _scheduler.ScheduleJob(simpleJobDetail, trigger);
            return Ok(simpleJobDetail);
        }
    }
}