using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikesSortTermerFactory
	: ISortTermerFactory<PostCommentLikesSortTerm, IPostCommentLikesSortTermer, PostCommentLikeResponse>;
