namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimCommandRepository
{
    Task AddAsync(UserClaim entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken);

    Task DeleteAsync(UserClaim entity, CancellationToken cancellationToken);

    Task<UserClaim?> GetByIdAsync(UserClaimId id, CancellationToken cancellationToken);

    Task<UserClaim?> GetByIdAsync(UserClaimId id, UserClaimInclude? include, CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(UserClaimId id, CancellationToken cancellationToken);
}
