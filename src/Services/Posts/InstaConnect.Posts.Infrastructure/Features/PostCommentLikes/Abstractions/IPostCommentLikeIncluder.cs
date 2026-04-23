using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

internal interface IPostCommentLikeIncluder : IIncluder<PostCommentLike, PostsIncludeType, PostsDestinationType>;
