namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

internal interface IUserCollectionResponseFactory
{
    UserCollectionResponse Create(ICollection<UserResponse> users, long totalCount, UsersPaginationQuery pagination);
}
