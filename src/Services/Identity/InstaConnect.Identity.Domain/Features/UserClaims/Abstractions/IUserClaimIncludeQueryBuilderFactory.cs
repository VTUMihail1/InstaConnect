using InstaConnect.UserClaims.Domain.Features.UserClaims.Helpers;

namespace InstaConnect.UserClaims.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimIncludeQueryBuilderFactory
{
    UserClaimIncludeQueryBuilder Create();
}