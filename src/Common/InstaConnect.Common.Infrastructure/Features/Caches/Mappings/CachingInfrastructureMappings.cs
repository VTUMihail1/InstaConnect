using CloudinaryDotNet.Actions;

using InstaConnect.Common.Application.Features.Caches.Models;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Mapster;

using Microsoft.Extensions.Caching.Distributed;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Mappings;

public class CachingInfrastructureMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CacheRequest, DistributedCacheEntryOptions>()
			.ConstructUsing(src => new()
			{
				AbsoluteExpiration = src.Expiration,
			});

		config.NewConfig<ImageUploadResult, Image>()
			.ConstructUsing(src => new(src.Url.AbsoluteUri));
	}
}
