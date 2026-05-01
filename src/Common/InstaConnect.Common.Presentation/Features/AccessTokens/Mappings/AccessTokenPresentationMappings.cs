using InstaConnect.Common.Application.Features.AccessTokens.Models;
using InstaConnect.Common.Presentation.Features.AccessTokens.Models.Responses;

using Mapster;

namespace InstaConnect.Common.Presentation.Features.AccessTokens.Mappings;

internal class AccessTokenPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<AccessTokenCommandResponse, AccessTokenApiResponse>()
			.ConstructUsing(src => new(
				src.Value,
				src.ExpiresAtUtc));
	}
}
