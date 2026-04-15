using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

internal interface IPostIncluder : IIncluder<Post, PostsIncludeType, PostsDestinationType>;
