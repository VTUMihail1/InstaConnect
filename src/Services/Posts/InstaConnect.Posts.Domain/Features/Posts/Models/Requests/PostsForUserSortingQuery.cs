using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostsForUserSortingQuery(
	CommonSortOrder Order,
	PostsForUserSortTerm Term) : ISortingQuery<PostsForUserSortTerm>;
