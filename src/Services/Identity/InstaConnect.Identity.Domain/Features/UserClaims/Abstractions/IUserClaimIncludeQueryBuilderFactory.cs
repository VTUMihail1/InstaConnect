using InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimIncludeQueryBuilderFactory
{
    UserClaimIncludeQueryBuilder Create();
}