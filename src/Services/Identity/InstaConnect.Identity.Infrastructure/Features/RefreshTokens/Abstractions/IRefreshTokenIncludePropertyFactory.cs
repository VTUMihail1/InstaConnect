using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IRefreshTokenIncludePropertyFactory
{
    ICollection<IRefreshTokenIncludeProperty> Create(ICollection<RefreshTokenIncludeProperty>? includeProperties);
}
