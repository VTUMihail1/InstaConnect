using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikesSortTermer : ISortTermer<PostCommentLikesSortTerm, PostCommentLikeResponse>;
