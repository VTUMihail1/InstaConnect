using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

internal interface IPostLikeIncluderFactory
    : IIncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostLikeIncluder, PostLike>;
