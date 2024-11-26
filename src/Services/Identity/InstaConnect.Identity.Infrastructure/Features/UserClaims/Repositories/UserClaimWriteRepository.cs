using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Repositories;

internal class UserClaimWriteRepository : IUserClaimWriteRepository
{
    private readonly IdentityContext _identityContext;

    public UserClaimWriteRepository(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<ICollection<UserClaim>> GetAllAsync(UserClaimCollectionWriteQuery query, CancellationToken cancellationToken)
    {
        var entities = await _identityContext
            .UserClaims
            .Where(uc => string.IsNullOrEmpty(query.UserId) || uc.UserId == query.UserId)
            .ToListAsync(cancellationToken);

        return entities;
    }

    public void Add(UserClaim userClaim)
    {
        _identityContext
            .UserClaims
            .Add(userClaim);
    }

}
