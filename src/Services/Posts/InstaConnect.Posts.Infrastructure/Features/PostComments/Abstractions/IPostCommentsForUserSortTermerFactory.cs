using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentsForUserSortTermerFactory
	: ISortTermerFactory<PostCommentsForUserSortTerm, IPostCommentsForUserSortTermer, PostCommentResponse>;
