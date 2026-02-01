using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluderFactory
    : IIncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IUserIncluder, User>;
