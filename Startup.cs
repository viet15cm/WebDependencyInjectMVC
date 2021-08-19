using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebDependencyInjectMVC.Services;

namespace WebDependencyInjectMVC
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
            // DIch vu nay co the inject vao cac dich vu khac , hoac inject vao cac controller
            // Vi du ta inject vao home controler
            //services.AddSingleton<ProductService>();
            services.AddSingleton<ProductService>((provider) => {
               
                var products = new List<Product>();
                products.AddRange(new Product[] {

                    new Product(){ Id ="1" , Name ="Dien Thoai IP" , Price = 50000 },
                    new Product(){ Id ="2" , Name ="Dien Thoai ss" , Price = 60000 },
                    new Product(){ Id ="3" , Name ="Dien Thoai tt" , Price = 70000 },
                    new Product(){ Id ="4" , Name ="Dien Thoai ll" , Price = 80000 },
                });
                var productSevice = new ProductService(products);
 //               var product = new ProductService(ProductService.GetListFile());
                return productSevice;
            });
            services.AddControllersWithViews();

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
                    pattern: "{controller=Home}/{action=ProductInfo}/{id?}");
            });
        }
    }
}
