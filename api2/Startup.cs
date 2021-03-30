using api2.Data;
using api2.models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using System;
//using  Microsoft.AspNetCore.Authentication.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api2
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
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("MilanoteApitest")));
            services.AddControllers();
            services.AddIdentity<IdentityUser, IdentityRole>(

                options =>
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;

                    options.Password.RequireLowercase = true;

                }).AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(auth =>
             {
                 auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             }
             ).AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = "https://localhost:44398",
                     ValidIssuer = "https://localhost:44398",
                     RequireExpirationTime = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is our key")),
                     ValidateIssuerSigningKey = true

                 };
             }
             );
            services.AddScoped<ItemRepos, ITaskRepos>();
            services.AddScoped<UserRepos, IUserRepos>();
            services.AddCors(options => {
                options.AddPolicy("_myAllowSpecificOrigins", builder =>
builder.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
            });

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
            app.UseCors("_myAllowSpecificOrigins");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
