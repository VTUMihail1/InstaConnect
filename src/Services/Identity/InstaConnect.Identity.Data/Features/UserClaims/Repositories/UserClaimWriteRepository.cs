using InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Identity.Data.Features.UserClaims.Repositories;

internal class UserClaimWriteRepository : BaseWriteRepository<UserClaim>, IUserClaimWriteRepository
{
    public UserClaimWriteRepository(IdentityContext identityContext) : base(identityContext)
    {
    }
}
