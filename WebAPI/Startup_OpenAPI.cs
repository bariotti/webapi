using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApi.Base.Models;
using WebApi.Base.Repository;
using WebApi.DTO;

namespace WebAPI
{
    public class Startup_OpenAPI
    {
        public Startup_OpenAPI(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IPessoaRepository, PessoaRepositoryInMemory>();

            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AllowNullCollections = true;
                c.CreateMap<PessoaDTO, Pessoa>();
                c.CreateMap<Pessoa, PessoaDTO>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddOData();

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("doc", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "WEB API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Bruno Bariotti",
                        Email = "bruno.bariotti@gmail.com"
                    },
                    Description = "Documentação sobre a utilização das APIs do projetos WEB API"
                });
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/doc/swagger.json", "WEB API - OpenAPI - UI");
            });

            app.UseMvc();

            /*app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().Count().OrderBy().Filter();
            });*/
        }
    }
}
