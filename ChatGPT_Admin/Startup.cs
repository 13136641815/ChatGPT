using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ChatGPT_Admin
{
    public class Startup
    {
        IWebHostEnvironment _environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;//���Դ�Сд��ƥ��model�ֶδ�Сд
                                                                      //opt.JsonSerializerOptions.IgnoreNullValues = false;//������Ҳ����
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // ����ʱ���ʽ
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();//���Controller�н��� dynamic ��ʽ����ȷ�����⣬ԭ��NetCore3.0+Ĭ�ϵĶ������л���������ΪSystem.Text.Json�µ�JsonDocument�����ĳ� Newtonsoft.Json
            });
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=ChatGPT}/{controller=Home}/{action=List}/{id?}");
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
