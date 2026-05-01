using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

internal interface IPostCommentLikesForUserSortTermer : ISortTermer<PostCommentLikesForUserSortTerm, PostCommentLikeResponse>;
