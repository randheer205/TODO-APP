using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.CategoryData;
using TODO.Models;
using TODO.TaskData;

namespace TODO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }
            );
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddControllers();
            services.AddDbContextPool<TasksAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TASKAPPConnectionString")));
            services.AddScoped<ICategoryInterface, SqlCategoryData>();
            services.AddScoped<ITaskInterface, SqlTaskData>();

            //services.AddDbContextPool<CategoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TASKAPPConnectionString")));
            //services.AddSingleton<ICategoryInterface, MockCategoryData>();


            //services.AddDbContextPool<TaskContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TASKAPPConnectionString")));
            //services.AddSingleton<ITaskInterface, MockTaskData>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
