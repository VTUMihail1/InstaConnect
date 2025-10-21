using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

public interface IUserIncludeProperty : IIncludeProperty<User>
{
    public UserIncludeProperty IncludeProperty { get; }
}
