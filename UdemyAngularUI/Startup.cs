using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UdemyAngularBusinessEngine.Contracts;
using UdemyAngularBusinessEngine.Implementaion;
using UdemyAngularData.DataContracts;
using UdemyAngularData.DataContext;
using UdemyAngularData.DbModels;
using UdemyAngularData.Implementaion;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UdemyAngularUI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace UdemyAngularUI
{
    public class Startup
    {
        [Obsolete]
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddControllers();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IItemBusinessEngine, ItemBusinessEngine>();
            services.AddScoped<ICustomerBusinessEngine, CustomerBusinessEngine>();
            services.AddScoped<IOrderBusinessEngine, OrderBusinessEngine>();
            services.AddDbContext<UdemyAngularDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<UdemyAngularDbContext>();

            services.AddScoped<IApplicationUserBusinessEngine, ApplicationUserBusinessEngine>();
            services.AddCors();


            var appSettingSection = Configuration.GetSection("Token");
            services.Configure<AppSettings>(appSettingSection);

            //JWT Authentication
            var appSettins = appSettingSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettins.Key);

            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddControllers().AddNewtonsoftJson(options =>
                             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                 .AllowCredentials();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
