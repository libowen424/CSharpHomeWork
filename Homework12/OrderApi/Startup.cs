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
            if (env.IsDevelopment()) { //机器的环境设置为Development
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); //启动http到https的重定向
            app.UseRouting();  //将路由组件添加到app中
            app.UseAuthorization(); //将授权组件添加到app中
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers(); //启动映射，将url路由到控制器
            });
        }
    }
}
