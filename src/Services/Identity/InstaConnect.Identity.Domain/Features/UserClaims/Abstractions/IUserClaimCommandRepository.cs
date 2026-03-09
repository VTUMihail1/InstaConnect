namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimCommandRepository
{
    Task AddAsync(UserClaim entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken);
}
