using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserSortProperty
{
    public UserSortProperty SortProperty { get; }

    public string Property { get; }
}
