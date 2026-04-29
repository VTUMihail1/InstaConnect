using InstaConnect.Common.Domain.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikesPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
