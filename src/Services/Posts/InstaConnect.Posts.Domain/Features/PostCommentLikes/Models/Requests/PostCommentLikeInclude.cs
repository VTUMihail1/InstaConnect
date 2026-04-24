using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikeInclude(ICollection<PostsIncludeDescriptor> Descriptors)
    : IInclude<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>;
