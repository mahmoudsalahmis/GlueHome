using GlueHome.Application.Deliveries.Commands.CreateDelivery;
using GlueHome.Application.Middleware;
using MediatR;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace GlueHome.IoC
{
    internal static class MediatRHelper
    {
        internal static void AddMediatRPipeLine(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateDeliveryCommandValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerMiddleware<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationMiddleware<,>));
            services.AddMediatR(
                cfg => cfg.AsTransient(),
                typeof(CreateDeliveryCommand).GetTypeInfo().Assembly
            );
        }
    }
}
