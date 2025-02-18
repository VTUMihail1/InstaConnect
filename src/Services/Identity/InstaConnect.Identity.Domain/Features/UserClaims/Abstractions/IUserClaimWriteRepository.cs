using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
public interface IUserClaimWriteRepository
{
    void Add(UserClaim userClaim);
    Task<ICollection<UserClaim>> GetAllAsync(UserClaimCollectionWriteQuery query, CancellationToken cancellationToken);
}
