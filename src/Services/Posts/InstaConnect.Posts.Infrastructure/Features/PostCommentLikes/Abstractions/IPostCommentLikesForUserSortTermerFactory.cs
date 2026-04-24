using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

internal interface IPostCommentLikesForUserSortTermerFactory
    : ISortTermerFactory<PostCommentLikesForUserSortTerm, IPostCommentLikesForUserSortTermer, PostCommentLikeResponse>;
