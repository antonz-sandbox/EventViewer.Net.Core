using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EventViewerLogging.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }        

        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            //NOTE: Before running execute this command in powershell(run as administrator) once: "New-EventLog -LogName VladApp -Source VladAppSource"

            app.Run(context => {
                logger.LogTrace("Nothing to do");
                logger.LogDebug("Check it out");
                logger.LogInformation("Just FYI Vlad");
                logger.LogWarning("Attention Vlad");
                logger.LogError("AAAAAA");
                logger.LogCritical("All is lost!...");

                return context.Response.WriteAsync("Hi Vlad"); 
            });
        }
    }
}
