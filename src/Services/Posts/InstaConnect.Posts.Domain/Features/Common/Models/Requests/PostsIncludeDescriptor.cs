using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Domain.Features.Common.Models.Requests;

public record PostsIncludeDescriptor(
	PostsDestinationType DestinationType,
	PostsIncludeType IncludeType)
	: IIncludeDescriptor<PostsDestinationType, PostsIncludeType>;
