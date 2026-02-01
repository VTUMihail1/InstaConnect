namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
public interface IUserClaimCommandRepository
{
    Task AddAsync(UserClaim entity, CancellationToken cancellationToken);
}
