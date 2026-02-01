using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

internal interface IPostIncluderFactory
    : IIncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostIncluder, Post>;

