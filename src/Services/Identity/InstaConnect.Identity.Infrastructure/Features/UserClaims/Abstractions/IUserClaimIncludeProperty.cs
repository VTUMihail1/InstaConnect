namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimIncludeProperty : IIncludeProperty<UserClaim>
{
    public UserClaimIncludeProperty IncludeProperty { get; }
}
