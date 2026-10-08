using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeIncluderFactory
	: IIncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostCommentLikeIncluder, PostCommentLike>;
