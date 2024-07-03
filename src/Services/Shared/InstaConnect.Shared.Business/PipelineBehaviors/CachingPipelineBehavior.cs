using InstaConnect.Shared.Business.Abstractions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace InstaConnect.Shared.Business.PipelineBehaviors;

internal class CachingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IQuery<TResponse>, ICachable
{
    private readonly ICacheHandler _cacheHandler;
    private readonly ILogger<CachingPipelineBehavior<TRequest, TResponse>> _logger;

    public CachingPipelineBehavior(
        ICacheHandler cacheHandler,
        ILogger<CachingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _cacheHandler = cacheHandler;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var cachedResult = await _cacheHandler.GetAsync<TResponse>(request.Key, cancellationToken);

        if (cachedResult != null)
        {
            _logger.LogInformation("Cache hit for {RequestName}", requestName);

            return cachedResult;
        }

        _logger.LogInformation("Cache miss for {RequestName}", requestName);

        var data = await next();
        await _cacheHandler.SetAsync(request.Key, data!, cancellationToken);

        return data;
    }
}
