using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluder : IIncluder<User, PostsIncludeType, PostsDestinationType>;
