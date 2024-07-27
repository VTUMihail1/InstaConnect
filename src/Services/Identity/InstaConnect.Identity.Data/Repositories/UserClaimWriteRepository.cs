using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Identity.Data.Repositories;

internal class UserClaimWriteRepository : BaseWriteRepository<UserClaim>, IUserClaimWriteRepository
{
    public UserClaimWriteRepository(IdentityContext identityContext) : base(identityContext)
    {
    }
}
