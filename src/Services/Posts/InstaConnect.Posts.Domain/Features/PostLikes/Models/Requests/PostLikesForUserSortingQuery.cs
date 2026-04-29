using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikesForUserSortingQuery(
	CommonSortOrder Order,
	PostLikesForUserSortTerm Term) : ISortingQuery<PostLikesForUserSortTerm>;
