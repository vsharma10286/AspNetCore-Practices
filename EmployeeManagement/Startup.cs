using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW1 : Incoming Request");
            //    //await context.Response.WriteAsync("Hello from first middlware");
            //    await next();
            //    logger.LogInformation("MW1 : Outgoing Request");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2 : Incoming Request");
            //    //await context.Response.WriteAsync("Hello from first middlware");
            //    await next();
            //    logger.LogInformation("MW2 : Outgoing Request");
            //});


            #region Important-Note

            // when we use FileServerOption Object then we dont need app.UseDefaultFiles and app.UseStaticFiles Objects, bcs 

            // FileServerOption does the both things

            //DefaultFilesOptions filesOptions = new DefaultFilesOptions();
            //filesOptions.DefaultFileNames.Clear();
            //filesOptions.DefaultFileNames.Add("foo.html");

            //app.UseDefaultFiles(filesOptions);
            // app.UseStaticFiles();

            #endregion


            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");



            //app.UseFileServer(fileServerOptions);

            app.UseStaticFiles();
            //  app.UseMvcWithDefaultRoute();

            app.UseMvc(
                routes =>
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}")
                );

            app.Run(async (context) =>
            {
               // logger.LogInformation("MW2 : Incoming Request");
                await context.Response.WriteAsync("Hello World");
            });
        }
    }
}
