using MediatR;
using Microsoft.Extensions.Logging;

namespace InstaConnect.Shared.Business.Behaviors;

internal class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;

        _logger.LogInformation(
            "Processing request {RequestName}",
            requestName);

        return await next();
    }
}
