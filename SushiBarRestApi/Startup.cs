using SushiBarBusinessLogic.BusinessLogics;
using SushiBarBusinessLogic.Interfaces;
using SushiBarDatabaseImplement.Implements;
using SushiBarBusinessLogic.HelperModels;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Threading;

namespace SushiBarRestApi
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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<ISushiStorage, SushiStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<OrderLogic>();
            services.AddTransient<ClientLogic>();
            services.AddTransient<SushiLogic>();
            services.AddTransient<MailLogic>();
            services.AddControllers().AddNewtonsoftJson();
            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = "smtp.yandex.ru",
                SmtpClientPort = 456,
                MailLogin = "laba8wq@yandex.ru",
                MailPassword = "taback2001",
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMessageInfoStorage messageInfoStorage)
        {
            var timer = new Timer(new TimerCallback(MailCheck), new MailCheckInfo
            {
                PopHost = "imap.yandex.ru",
                PopPort = 993,
                Storage = messageInfoStorage
            }, 0, 100000);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void MailCheck(object obj)
        {
            MailLogic.MailCheck((MailCheckInfo)obj);
        }
    }
}
