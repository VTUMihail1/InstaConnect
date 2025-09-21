using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
public interface IUserSortPropertyFactory
{
    IUserSortProperty Create(UserSortProperty sortProperty);
}
