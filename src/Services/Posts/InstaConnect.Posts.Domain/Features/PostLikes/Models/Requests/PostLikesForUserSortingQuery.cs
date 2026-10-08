using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikesForUserSortingQuery(
	CommonSortOrder Order,
	PostLikesForUserSortTerm Term) : ISortingQuery<PostLikesForUserSortTerm>;
