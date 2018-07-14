﻿using AndroidManager.Web.Automapper;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AndroidManager.Web
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
            // получаем строку подключения из файла конфигурации
            services.AddDbContext<DatabaseContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // добавляем контекст DatabaseContext в качестве сервиса в приложение
            services.AddTransient<JobService, JobService>();

            services.AddTransient<AndroidService, AndroidService>();

            services.AddCors();

            services.AddAutoMapper();
            // add AutoMapper profiles
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new JobProfile());
                cfg.AddProfile(new AndroidProfile());
            });

            services.AddMvc()
                .AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("*")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseMvc();
        }
    }
}

