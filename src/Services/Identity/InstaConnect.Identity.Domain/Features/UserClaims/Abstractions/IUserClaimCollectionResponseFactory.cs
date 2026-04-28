namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

internal interface IUserClaimCollectionResponseFactory
{
    UserClaimCollectionResponse Create(UserResponse? user, ICollection<UserClaimResponse> userClaims, long totalCount, UserClaimsPaginationQuery pagination);
}
