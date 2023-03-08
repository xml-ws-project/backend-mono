using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

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
        }
    }
}
