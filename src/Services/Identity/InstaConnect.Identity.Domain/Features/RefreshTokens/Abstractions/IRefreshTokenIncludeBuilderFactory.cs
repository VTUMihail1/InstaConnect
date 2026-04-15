using InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludeBuilderFactory
{
    RefreshTokenIncludeBuilder Create();
}
