using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace bokeSite
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "小胡微博接口文档",
                    Description = "小胡微博接口帮助文档",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "胡周瑜", Email = "a1085052074@qq.com", Url = "https://weibo.com/u/2304451421?from=hissimilar_home&refer_flag=1005050003_" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = System.IO.Directory.GetCurrentDirectory();
                var xmlPath = Path.Combine(basePath, "bokeSite.xml");
                c.IncludeXmlComments(xmlPath);

                //  c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });










            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.Usetest404();
            // app.UseStatusCodePagesWithRedirects("/boke/test404");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocExpansion("胡周瑜文档接口");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "微博前端接口");
             
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=boke}/{action=tmpIndex}/{id?}");
            });
        }
    }
}
