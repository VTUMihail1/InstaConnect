using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Models;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;
public interface IRefreshTokenQueryFactory
{
    GetRefreshTokenByIdQuerySpecification CreateGetById(string id, string value);
}
