using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shop.DatabaseContext;
using Shop.Entity;
using Shop.Entity.Impl;
using Shop.Filter;
using Shop.Service;
using Shop.Service.Impl;

namespace Shop
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
            // 配置使用WebAPI2
            services.AddControllers();
            // 配置使用跨域访问
            services.AddCors(option => option.AddPolicy("Any", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            // 将SQL Server的数据库上下文注入到DI容器
            services.AddDbContext<SqlServerDatabaseContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("SQLServerConnectionString")));

            // 将过滤器注入到DI容器
            services.AddScoped<LoginFilterAttribute>();

            // 将数据访问层的类注入到DI容器中
            services.AddScoped<ICustomerEntity, CustomerEntity>();
            services.AddScoped<ILocationEntity, LocationEntity>();
            services.AddScoped<ICustomerLocationEntity, CustomerLocationEntity>();
            services.AddScoped<IAdministratorEntity, AdministratorEntity>();
            services.AddScoped<IProductEntity, ProductEntity>();
            services.AddScoped<IKindEntity, KindEntity>();
            services.AddScoped<ISupplierEntity, SupplierEntity>();
            services.AddScoped<IProductSupplierEntity, ProductSupplierEntity>();
            services.AddScoped<IOrderEntity, OrderEntity>();
            services.AddScoped<IItemEntity, ItemEntity>();

            // 将业务层的类注入到DI容器中
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICustomerLocationService, CustomerLocationService>();
            services.AddScoped<IAdministratorService, AdministratorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShopService, ShopService>();

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

            // 启用跨域访问
            app.UseCors("Any");

            // 启用WebAPI2
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
