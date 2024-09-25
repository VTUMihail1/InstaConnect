using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;

namespace InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
public interface IUserClaimWriteRepository
{
    void Add(UserClaim userClaim);
    Task<ICollection<UserClaim>> GetAllAsync(UserClaimCollectionWriteQuery query, CancellationToken cancellationToken);
}
