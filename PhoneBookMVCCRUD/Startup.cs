using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PhoneBookMVCCRUD.Domain.Repositories.Abstract;
using PhoneBookMVCCRUD.Domain.Repositories.EF;
using PhoneBookMVCCRUD.Domain;

namespace PhoneBookMVCCRUD
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем Config из appsettings.json для получения connectionString
            Configuration.Bind("PhoneBook", new Config());

            //подключаем сервисы
            services.AddTransient<IPhoneBookRecordRepository, EFPhoneBookRecordsRepository>();
            services.AddTransient<DataManager>();

            //подключаем контекст БД
            services.AddDbContext<AppDBContext>(x => x.UseSqlServer(Config.ConnectionString));

            //поддержка контроллеров и представлений
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //подключаем поддержку статичных файлов
            app.UseStaticFiles();

            //подключаем систему маршрутизации
            app.UseRouting();

            //регистрируем маршруты(endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
