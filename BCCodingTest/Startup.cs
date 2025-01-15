using BCCodingTest.Common;
using BCCodingTest.Handler;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace BCCodingTest
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<StudentsListHandleService>();
            services.AddControllers();
            services.AddSwaggerGen(u => {
                u.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "Ver:1.0.0",
                    Title = "BCCodingTest",
                    Description = "",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Kaka"
                    }
                });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("allowSpecificOrigins");
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "Test");
            });

            app.UseRouting();
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    if (exception != null)
                    {
                        var error = new ErrorMessage()
                        {
                            StackTrace = exception.Error.StackTrace,
                            Message = exception.Error.Message
                        };
                        var errObj = JsonConvert.SerializeObject(error);

                        await context.Response.WriteAsync(errObj).ConfigureAwait(false);
                    }
                });
            });
            app.UseAuthorization();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
