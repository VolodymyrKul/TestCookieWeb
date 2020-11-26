using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestCookieWeb.Core.Abstractions;
using TestCookieWeb.Core.Abstractions.IServices;
using TestCookieWeb.Core.Mapping;
using TestCookieWeb.DAL;
using TestCookieWeb.Extensions;
using TestCookieWeb.Services;

namespace TestCookieWeb
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Data Source=DESKTOP-THTGA2V;Initial Catalog=TestCookieDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<TestCookiesDbContext>(e => e.UseSqlServer(connectionString));
            services.ConfigureInfrastructureServices();
            services.ConfigureAuthentication(Configuration);
            services.ConfigureMapping();
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.ConfigureSwagger();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200").AllowAnyHeader();
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            //Allow secure protocol usage
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            //Allow user authorization
            app.UseAuthorization();
            //Allow per-request caching
            app.UseCors(MyAllowSpecificOrigins);
            app.UseResponseCaching();

            //app.UseMiddleware<CookieMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
