using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluder : IIncluder<User, PostsIncludeType, PostsDestinationType>;
