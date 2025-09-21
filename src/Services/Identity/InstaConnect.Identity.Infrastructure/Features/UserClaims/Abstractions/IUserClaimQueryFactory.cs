using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
public interface IUserClaimQueryFactory
{
    GetAllUserClaimsQuerySpecification CreateGetAll(GetAllUserClaimsQuery query);
}
