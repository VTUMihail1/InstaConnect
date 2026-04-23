using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentInclude(ICollection<PostsIncludeDescriptor> Descriptors)
    : IInclude<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>;
