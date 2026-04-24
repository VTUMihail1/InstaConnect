using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostInclude(ICollection<PostsIncludeDescriptor> Descriptors)
    : IInclude<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>;
