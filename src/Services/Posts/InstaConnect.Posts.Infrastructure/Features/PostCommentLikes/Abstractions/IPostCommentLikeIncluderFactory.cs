using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

internal interface IPostCommentLikeIncluderFactory
	: IIncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostCommentLikeIncluder, PostCommentLike>;
