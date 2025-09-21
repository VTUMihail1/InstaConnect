using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
public interface IUserClaimRepository
{
    Task<UserClaimCollection> GetAllAsync(GetAllUserClaimsQuery query, CancellationToken cancellationToken);

    void Add(UserClaim userClaim);
}
