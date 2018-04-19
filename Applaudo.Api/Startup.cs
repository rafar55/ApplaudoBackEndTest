using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Applaudo.Core.Implementaciones;
using Applaudo.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Applaudo.Api
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
      services
        .AddMvc()
        .AddJsonOptions(opt =>
        {
          //Le digo al formater que los default values los ignore
          //Esto para cumplir con el requerimiento que quiere que el disable false no salga
          opt.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
        });

      //configuro el swagger para facilitar la documentacion de la api
      services.AddSwaggerGen(opt =>
      {
        opt.SwaggerDoc("v1",
          new Info()
          {
            Title = "Applaudo Studio Back-End Api Test",
            Version = "v1",
            Contact = new Contact() {Email = "rafa@bitworks.com.sv", Name = "Rafael Romero",Url = "http://solid.com.sv"},
            Description = "Api sencilla de prueba creada con Asp.Net Core"
          });

        var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        var xmlPathCore = Path.Combine(AppContext.BaseDirectory, "Applaudo.Core.xml");

        opt.IncludeXmlComments(xmlPath);
        opt.IncludeXmlComments(xmlPathCore);
      });
    

      //Registro la implementacion del repositori en el DI container
      services.AddScoped<IPersonasRepository, PersonaRepositoryInMemory>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

    

      //pongo el middleware para el json endpoint del swagger
      app.UseSwagger();

      //configuro el middleware para el UI del Swagger
      app.UseSwaggerUI(opt =>
      {
         opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Applaudo Api Test");
      });

      //Hago que browser por default muestre el ui de Swagger
      var option = new RewriteOptions();
      option.AddRedirect("^$", "swagger");
      app.UseRewriter(option);

      app.UseMvc();
    }
  }
}