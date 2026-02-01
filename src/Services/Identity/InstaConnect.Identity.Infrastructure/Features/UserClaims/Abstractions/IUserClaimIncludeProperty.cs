namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimIncludeProperty : IIncluder<UserClaim>
{
    public UserClaimIncludeProperty IncludeProperty { get; }
}
