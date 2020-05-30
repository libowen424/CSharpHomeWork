using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace OrderApi
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
            services.AddDbContextPool<OrderContext>(options => options
                .UseMySql(Configuration.GetConnectionString("orderDatabase"),
                mySqlOptions => mySqlOptions.ServerVersion(new Version(8, 0, 20), ServerType.MySql)
            ));

            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { //�����Ļ�������ΪDevelopment
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); //����http��https���ض���
            app.UseRouting();  //��·�������ӵ�app��
            app.UseAuthorization(); //����Ȩ�����ӵ�app��
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers(); //����ӳ�䣬��url·�ɵ�������
            });
        }
    }
}
