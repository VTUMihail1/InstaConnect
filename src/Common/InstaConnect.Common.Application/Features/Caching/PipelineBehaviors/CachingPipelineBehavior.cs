using InstaConnect.Common.Application.Features.Caching.Abstractions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

using MediatR;

using Microsoft.Extensions.Logging;

namespace InstaConnect.Common.Application.Features.Caching.PipelineBehaviors;

internal class CachingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IQueryRequest<TResponse>, ICachable
    where TResponse : class
{
    private readonly ICacheHandler _cacheHandler;
    private readonly ICacheRequestFactory _cacheRequestFactory;
    private readonly ILogger<CachingPipelineBehavior<TRequest, TResponse>> _logger;

    public CachingPipelineBehavior(
        ICacheHandler cacheHandler,
        ICacheRequestFactory cacheRequestFactory,
        ILogger<CachingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _cacheHandler = cacheHandler;
        _cacheRequestFactory = cacheRequestFactory;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestKey = request.Key;
        var cachedResult = await _cacheHandler.GetAsync<TResponse>(requestKey, cancellationToken);

        if (cachedResult != null)
        {
            _logger.LogInformation("Cache hit for key {RequestKey}", requestKey);

            return cachedResult;
        }

        _logger.LogInformation("Cache miss for {RequestKey}", requestKey);

        var data = await next(cancellationToken);
        var cacheRequest = _cacheRequestFactory.Get(requestKey, request.ExpirationSeconds, data);
        await _cacheHandler.SetAsync(cacheRequest, cancellationToken);

        return data;
    }
}
