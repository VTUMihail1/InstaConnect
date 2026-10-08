using InstaConnect.Common.Domain.Features.Requests.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentsPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
