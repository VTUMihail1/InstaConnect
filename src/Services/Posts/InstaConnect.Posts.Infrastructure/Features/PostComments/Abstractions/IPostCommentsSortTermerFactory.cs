using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

internal interface IPostCommentsSortTermerFactory
	: ISortTermerFactory<PostCommentsSortTerm, IPostCommentsSortTermer, PostCommentResponse>;
