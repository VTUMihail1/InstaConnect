namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimCommandService
{
	public Task<UserClaimId> AddAsync(AddUserClaimCommand command, CancellationToken cancellationToken);

	public Task DeleteAsync(DeleteUserClaimCommand command, CancellationToken cancellationToken);
}
