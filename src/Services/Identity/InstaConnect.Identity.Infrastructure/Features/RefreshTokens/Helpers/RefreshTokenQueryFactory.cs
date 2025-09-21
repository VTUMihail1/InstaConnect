using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Models;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Utilities;

namespace InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Helpers;

public class RefreshTokenQueryFactory : IRefreshTokenQueryFactory
{
    public GetRefreshTokenByIdQuerySpecification CreateGetById(string id, string value)
    {
        var parameters = new GetRefreshTokenByIdQueryParameters(id, value);

        var result = new GetRefreshTokenByIdQuerySpecification(
            RefreshTokenQuerySql.GetById,
            parameters);

        return result;
    }
}
