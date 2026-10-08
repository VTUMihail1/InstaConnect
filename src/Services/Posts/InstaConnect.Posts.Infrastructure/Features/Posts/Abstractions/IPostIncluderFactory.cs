using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostIncluderFactory
	: IIncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostIncluder, Post>;

