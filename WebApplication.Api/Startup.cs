using System;
using System.IO;
using System.Text;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Abstraction.Interfaces.Commands;
using BusinessLogicLayer.Implementation.Services;
using BusinessLogicLayer.Implementation.Services.Commands;
using DataAccessLayer.Models.MapperProfiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace WebApplication.Api
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
            services.AddControllers().AddNewtonsoftJson();
            
            services.AddSingleton<ITelegramBotService, TelegramBotService>();
            services.AddSingleton<ICurrencyProvider, CbrExchangeRateProviderService>();
            services.AddSingleton<IGetRateCommand, GetRateCommand>();
            services.AddAutoMapper(typeof(ExchangeRateMappingProfile));
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

//            app.Use(async (context, next) =>
//            {
//                var logger = context.RequestServices.GetService<ILogger<TelegramBotClient>>();
//
//
//                Console.WriteLine(context.Request.Method);
//                Console.WriteLine(context.Request.GetTypedHeaders().ContentType.ToString());
//                
//                var result = new MemoryStream();
//
//                await context.Request.Body.CopyToAsync(result);
//
//                context.Request.Body.Seek(0, SeekOrigin.Begin);
//
//                var body = Encoding.UTF8.GetString(result.ToArray());
//
//                Console.WriteLine(body);
//                //logger.LogInformation(string.Join(",", context.Request.ToKeyValuePairs()));
//
//
//                await next();
//            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


            app.ApplicationServices.GetService<ITelegramBotService>().Get();
        }
    }
}