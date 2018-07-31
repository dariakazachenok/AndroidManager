using AndroidManager.Web.Automapper;
using AndroidManager.Web.Models;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            services.AddTransient<JobService, JobService>();
            services.AddTransient<AndroidService, AndroidService>();
            services.AddTransient<OperatorService, OperatorService>();

            services.AddCors();

            services.AddMvc()
                .AddFluentValidation();

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });
            AddAutomapperProfiles(services);
            AddAuth(services);

        }

        private void AddAuth(IServiceCollection services)
        {
            services.AddSingleton(Configuration.GetSection("JWT").Get<JwtConfigurationModel>());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
        }

        private void AddAutomapperProfiles(IServiceCollection services)
        {
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new JobProfile());
                cfg.AddProfile(new AndroidProfile());
            }).CreateMapper());
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
                     .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}

