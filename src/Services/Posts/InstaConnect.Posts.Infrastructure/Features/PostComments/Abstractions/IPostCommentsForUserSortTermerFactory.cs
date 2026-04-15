namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

internal interface IPostCommentsForUserSortTermerFactory
    : ISortTermerFactory<PostCommentsForUserSortTerm, IPostCommentsForUserSortTermer, PostCommentResponse>;
