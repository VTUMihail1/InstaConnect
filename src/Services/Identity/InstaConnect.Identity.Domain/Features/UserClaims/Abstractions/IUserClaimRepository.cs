using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
public interface IUserClaimRepository
{
    Task AddAsync(UserClaim entity, CancellationToken cancellationToken);
}
