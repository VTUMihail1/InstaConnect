using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Identity.Data.Repositories;

internal class UserClaimRepository : BaseRepository<UserClaim>, IUserClaimRepository
{
    private readonly IdentityContext _identityContext;

    public UserClaimRepository(IdentityContext identityContext) : base(identityContext)
    {
        _identityContext = identityContext;
    }
}
