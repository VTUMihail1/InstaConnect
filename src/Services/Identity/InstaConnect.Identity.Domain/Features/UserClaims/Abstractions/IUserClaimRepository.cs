namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
public interface IUserClaimRepository
{
    Task AddAsync(UserClaim entity, CancellationToken cancellationToken);
}
