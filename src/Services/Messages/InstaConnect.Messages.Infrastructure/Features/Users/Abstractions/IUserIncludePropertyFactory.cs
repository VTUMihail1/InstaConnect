using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IUserIncludePropertyFactory
{
    ICollection<IUserIncludeProperty> Create(ICollection<UserIncludeProperty>? includeProperties);
}
