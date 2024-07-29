using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
public interface IUserClaimWriteRepository : IBaseWriteRepository<UserClaim>
{
}
