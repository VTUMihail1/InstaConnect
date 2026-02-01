namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;
public interface IUserQueryService
{
    public Task<UserCollectionResponse> GetAllAsync(GetAllUsersQuery query, CancellationToken cancellationToken);

    public Task<UserResponse> GetByIdAsync(GetUserByIdQuery query, CancellationToken cancellationToken);
}
