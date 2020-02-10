using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TODO_HTTP_API.DataAcceess;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Services;
using AutoMapper;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.BusinessLogic.Helpers.Services;
using TODO_HTTP_API.BusinessLogic.Helpers.Interfaces;
using TODO_HTTP_API.DataAcceess.Entities;
using TODO_HTTP_API.WebApi.Swagger;

namespace TODO_HTTP_API.WebApi
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
            services.AddControllers();

            //EntityFramework
            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<ApplicationContext>(opt =>
                    {
                        opt.UseSqlServer(Configuration.GetConnectionString("LocalSql"),
                                      m => m.MigrationsAssembly("TODO_HTTP_API.WebApi"));
                    });

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));
            //Swagger
            services.AddSwaggerServices();
            //Dependency injection
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IToDoListService, ToDoListService>();
            services.AddScoped<ISortHelper<Task>, SortHelper<Task>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
