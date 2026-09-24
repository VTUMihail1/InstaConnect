using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentsSortingQuery(
	CommonSortOrder Order,
	PostCommentsSortTerm Term) : ISortingQuery<PostCommentsSortTerm>;
