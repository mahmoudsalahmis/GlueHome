using GlueHome.Application.Deliveries.Commands.UpdateDeliveryStatus;
using GlueHome.Application.Deliveries.Commands.CreateDelivery;
using GlueHome.Application.Deliveries.Commands.DeleteDelivery;
using GlueHome.Application.Deliveries.Commands.UpdateDelivery;
using GlueHome.Application.Deliveries.Queries.GetDeliveryById;
using GlueHome.Persistence;
using GlueHome.Persistence.Repositories.Deliveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GlueHome.IoC
{
    public static class PersistenceHelper
    {
        internal static void AddGlueHomeDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GlueHomeDbContext>(o =>
                {
                    o.UseSqlServer(configuration.GetConnectionString("GlueHomeDb"), p => p.EnableRetryOnFailure());
                });

            services.TryAddScoped<ICreateDeliveryRepository, CreateDeliveryRepository>();
            services.TryAddScoped<IUpdateDeliveryRepository, UpdateDeliveryRepository>();
            services.TryAddScoped<IGetDeliveryByIdRepository, GetDeliveryByIdRepository>();
            services.TryAddScoped<IDeleteDeliveryRepository, DeleteDeliveryRepository>();
            services.TryAddScoped<IUpdateDeliveryStatusRepository, UpdateDeliveryStatusRepository>();
        }
    }
}
