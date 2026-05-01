namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimQueryService
{
	public Task<UserClaimCollectionResponse> GetAllAsync(GetAllUserClaimsQuery query, CancellationToken cancellationToken);
}
