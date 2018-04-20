using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PertaminaQuestionnaire.Models;

namespace PertaminaQuestionnaire
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
            services.AddMvc();

            string connString = @"Server=localhost,1433;Database=master;User Id=sa;Password=reallyStrongPwd123;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=false";
            services.AddDbContext<PertaminaQADBContext>(opt => opt.UseSqlServer(connString));
            //services.AddDbContext<PertaminaQADBContext>(opt => opt.UseInMemoryDatabase("PertaminaQADBContext"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
