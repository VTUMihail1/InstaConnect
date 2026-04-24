using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikeInclude(ICollection<PostsIncludeDescriptor> Descriptors)
    : IInclude<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>;
