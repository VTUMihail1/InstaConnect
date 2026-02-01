using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

internal interface IPostLikeIncluderFactory
    : IIncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostLikeIncluder, PostLike>;
