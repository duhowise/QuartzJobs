using System.Collections.Specialized;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using QuartzJobs.Jobs;
using QuartzJobs.Services;

namespace QuartzJobs
{
    public class Startup
    {
        private readonly IScheduler _quartzScheduler;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _quartzScheduler = ConfigureQuartz();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton(provider=>_quartzScheduler);
            services.AddTransient<IEmailSender,EmailService>();
            services.AddTransient<SimpleJob>();
            services.AddSwaggerGen(swaggerOptions =>
            {
                swaggerOptions.SwaggerDoc("v1",new OpenApiInfo{Title = "Jobs Api",Version = "v1"});
            });
        }

        public void OnShutDown()
        {
            if (!_quartzScheduler.IsShutdown) _quartzScheduler.Shutdown();
            
        }

        private IScheduler ConfigureQuartz()
        {
            var props=new NameValueCollection
            {

                {"quartz.serializer.type","binary" }
            };
            var factory=new StdSchedulerFactory(props);
            var scheduler = factory.GetScheduler().Result;
            scheduler.Start().Wait();
            //scheduler.ListenerManager.AddTriggerListener(new TriggerListener(),GroupMatcher<TriggerKey>.GroupEquals("Jobs"));
            scheduler.ListenerManager.AddTriggerListener(new TriggerListener());
            return scheduler;


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(uiOptions =>
            {
                uiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Jobs Api");
            }); app.UseMvc();
           
        }
    }
}
