using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applaudo.Core.Implementaciones;
using Applaudo.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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

      //configuro algunas opciones personalidas del formater del json
    

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

      app.UseMvc();
    }
  }
}