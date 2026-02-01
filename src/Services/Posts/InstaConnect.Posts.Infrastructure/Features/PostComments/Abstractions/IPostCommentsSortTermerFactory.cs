namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

internal interface IPostCommentsSortTermerFactory
    : ISortTermerFactory<PostCommentsSortTerm, IPostCommentsSortTermer, PostCommentResponse>;
