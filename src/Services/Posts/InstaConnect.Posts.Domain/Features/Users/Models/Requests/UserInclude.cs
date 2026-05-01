using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Users.Models.Requests;

public record UserInclude(ICollection<PostsIncludeDescriptor> Descriptors)
	: IInclude<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>;
