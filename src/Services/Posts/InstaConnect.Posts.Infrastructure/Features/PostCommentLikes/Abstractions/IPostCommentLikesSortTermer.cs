using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

internal interface IPostCommentLikesSortTermer : ISortTermer<PostCommentLikesSortTerm, PostCommentLikeResponse>;
