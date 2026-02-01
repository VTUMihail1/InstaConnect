using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

internal interface IPostLikeIncluder : IIncluder<PostLike, PostsIncludeType, PostsDestinationType>;
