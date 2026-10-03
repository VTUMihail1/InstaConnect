using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

public interface IUserIncluder : IIncluder<User, PostsIncludeType, PostsDestinationType>;
