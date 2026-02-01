using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

internal interface IPostCommentLikeIncluder : IIncluder<PostCommentLike, PostsIncludeType, PostsDestinationType>;
