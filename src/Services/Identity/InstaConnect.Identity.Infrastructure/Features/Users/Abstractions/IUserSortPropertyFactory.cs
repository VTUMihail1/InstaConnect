namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
public interface IUserSortPropertyFactory
{
    IUserSortProperty Create(UserSortProperty sortProperty);
}
