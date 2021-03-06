﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using FootballRankings.Api.Configurations;
using Swashbuckle.AspNetCore.Swagger;

namespace FootballRankings.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                new Info
                {
                    Title = "Documentação da Football Rankings API",
                    Description = "Football Rankings API",
                    Version = "v1.0",
                    Contact = new Contact
                    {
                        Name = "Fellipe Gomes Versiani",
                        Email = "fellipeversiani@gmail.com",
                        Url = "https://www.linkedin.com/in/f3llps/"
                    }
                });

                

            });

            services.WebApiConfig();

            services.ResolveDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "API FootballRankings");
                s.InjectStylesheet("/swagger-ui/custom.css");
                s.InjectJavascript("/swagger-ui/custom.js");
                //s.RoutePrefix = string.Empty;
            });
            
            //app.UseStaticFiles();
            app.UseMvcConfig(env);

        }
    }
}