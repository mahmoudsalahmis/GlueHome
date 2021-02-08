using GlueHome.Application.Deliveries.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GlueHome.IoC
{
    public static class Helper
    {
        public static void AddGlueHome(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatRPipeLine();

            services.AddAutoMapper(typeof(DeliveryModelProfile).GetTypeInfo().Assembly);

            services.AddGlueHomeDbConfiguration(configuration);
        }
    }
}
