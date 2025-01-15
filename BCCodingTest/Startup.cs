using BCCodingTest.Common;
using BCCodingTest.Handler;
using BCCodingTest.ServiceCheck;
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
            var httpServiceUrl = "https://www.baidu.com";
            services.AddHttpClient();
            var httpClient = services.BuildServiceProvider().GetRequiredService<HttpClient>();
            var checker = new HttpServiceConnectionChecker(httpServiceUrl, httpClient);
            if (!checker.CheckConnection().Result)
            {
                throw new Exception("HTTP服务连接失败");
            }
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var dataBaseChecker = new DatabaseConnectionChecker(connectionString);
            if (!checker.CheckConnection().Result)
            {
                throw new Exception("Database Server Connect Fail");
            }
            // 继续配置其他服务
            services.AddControllers();
            services.AddControllers();
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
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
