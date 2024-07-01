using System;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace InstaConnect.Shared.Business.Behaviors;

internal class CachingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IQuery<TResponse>, ICachable
{
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger<CachingPipelineBehavior<TRequest, TResponse>> _logger;

    public CachingPipelineBehavior(
        IMemoryCache memoryCache,
        ILogger<CachingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _memoryCache = memoryCache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var cachedResult = _memoryCache.Get<TResponse>(request.Key);

        if (cachedResult != null)
        {
            _logger.LogInformation("Cache hit for {RequestName}", requestName);

            return cachedResult;
        }

        _logger.LogInformation("Cache miss for {RequestName}", requestName);

        var data = await next();
        _memoryCache.Set(request.Key, data, request.Expiration);

        return data;
    }
}
