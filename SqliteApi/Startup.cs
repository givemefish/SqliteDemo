// =================================================================
// File: Startup.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/15 下午 04:12
// Update Date: 2018/03/19 下午 03:13
// =================================================================
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SqliteApi.Data;
using SqliteApi.Repositories;

namespace SqliteApi
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => { options.UseSqlite(Configuration["ConnectionStrings:DefaultConnection"]); });

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddScoped<IAppUserRepository, AppUserRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions()
            {
                ExceptionHandler = async context =>
                {
                    var isApi = Regex.IsMatch(context.Request.Path.Value, "^/api/", RegexOptions.IgnoreCase);
                    if (isApi)
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            var err = JsonConvert.SerializeObject(new
                            {
                                Message = "Internal Server Error"
                            });

                            await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(err), 0, err.Length);
                            return;
                        }
                    }

                    context.Response.Redirect("/error");
                }
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}