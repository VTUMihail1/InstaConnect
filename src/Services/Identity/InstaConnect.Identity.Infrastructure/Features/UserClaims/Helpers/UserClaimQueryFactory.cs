using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Utilities;

namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Helpers;

public class UserClaimQueryFactory : IUserClaimQueryFactory
{
    public GetAllUserClaimsQuerySpecification CreateGetAll(GetAllUserClaimsQuery query)
    {
        var parameters = new GetAllUserClaimsQueryParameters(query.Filter.Id);

        var specification = new GetAllUserClaimsQuerySpecification(
            UserClaimQuerySql.GetAll,
            parameters);

        return specification;
    }
}
