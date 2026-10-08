using InstaConnect.Common.Domain.Features.Databases.Models;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostInclude(ICollection<PostsIncludeDescriptor> Descriptors)
	: Include<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>(Descriptors);
