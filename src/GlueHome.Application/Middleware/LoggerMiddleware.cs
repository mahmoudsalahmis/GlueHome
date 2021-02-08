using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Middleware
{
    public class LoggerMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggerMiddleware<TRequest, TResponse>> _logger;

        public LoggerMiddleware(ILogger<LoggerMiddleware<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var name = typeof(TRequest).Name;
            TResponse response;
            try
            {
                _logger.LogInformation($"Invoking request {name} with the following value:{Environment.NewLine}{request}");
                response = await next();
                _logger.LogInformation($"Request completed and returned the following value:{Environment.NewLine}{response}");
            }
            catch (Exception ex)
            {
                _logger.LogError(default, ex, $"Error in Request {name} {Environment.NewLine} {Environment.NewLine} {request}");
                throw;
            }

            return response;
        }
    }
}
