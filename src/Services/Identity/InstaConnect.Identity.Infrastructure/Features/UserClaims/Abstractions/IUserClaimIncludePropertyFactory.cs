namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimIncludePropertyFactory
{
    IEnumerable<IUserClaimIncludeProperty> Create(ICollection<UserClaimIncludeProperty>? includeProperties);
}
