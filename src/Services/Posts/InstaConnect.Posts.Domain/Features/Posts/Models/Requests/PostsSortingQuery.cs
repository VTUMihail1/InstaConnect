using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostsSortingQuery(
	CommonSortOrder Order,
	PostsSortTerm Term) : ISortingQuery<PostsSortTerm>;
