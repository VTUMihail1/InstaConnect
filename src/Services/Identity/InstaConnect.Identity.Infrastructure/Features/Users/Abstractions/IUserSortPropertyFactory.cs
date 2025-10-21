using InstaConnect.Common.Models.Enums;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface IUserSortPropertyFactory
{
    IUserSortProperty Create(UserSortProperty sortProperty);
}
