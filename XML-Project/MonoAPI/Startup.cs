using AspNetCore.Identity.MongoDbCore.Infrastructure;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MonoAPI.AuthToken;
using MonoAPI.Configuration;
using MonoLibrary.Core.Context;
using MonoLibrary.Core.DbSettings;
using MonoLibrary.Core.Models.ApplicationUsers;
using MonoLibrary.Core.Repository;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service;
using MonoLibrary.Core.Service.Core;
using MonoLibrary.Core.Services;
using MonoLibrary.Core.Services.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MonoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "XML-PROJECT",
                    Description = "Best application in the world!",
                    Contact = new OpenApiContact
                    {
                        Name = "Our Contact ",
                        Url = new Uri("https://github.com/xml-ws-project")
                    }
                });
            });

            //Binding appsettings.json and DbSettings.cs
            services.Configure<DbSettings>(Configuration.GetSection("DbSettings"));
            services.AddSingleton<IDbSettings>(provider => 
                provider.GetRequiredService<IOptions<DbSettings>>().Value);

            //Binding appsettings.json and ProjectConfiguration
            ProjectConfiguration config = new ProjectConfiguration();
            Configuration.Bind("ProjectConfiguration", config);
            services.AddSingleton(config);

            //Identity setup
            var dbSettings = Configuration.GetSection("DbSettings").Get<DbSettings>();
            services.AddIdentity<User, Role>().AddMongoDbStores<User, Role, string>
                (
                    dbSettings.ConnectionString, dbSettings.DatabaseName
                );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ProjectConfiguration:Jwt:Key"])),
                    ValidIssuer = Configuration["ProjectConfiguration:Jwt:Issuer"],
                    ValidAudience = Configuration["ProjectConfiguration:Jwt:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };


            });

            //Register your services and repositories in this function
            RegisterServices(services);

            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => 
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "XML-PROJECT v1");
                    options.RoutePrefix = string.Empty;
                });
            
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IFlightLayoutRepository, FlightLayoutRepository>();
            services.AddScoped<IFlightLayoutService, FlightLayoutService>();
        }
    }
}
