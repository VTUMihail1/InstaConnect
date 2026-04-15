namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

internal interface IPostCommentLikesSortTermerFactory
    : ISortTermerFactory<PostCommentLikesSortTerm, IPostCommentLikesSortTermer, PostCommentLikeResponse>;
