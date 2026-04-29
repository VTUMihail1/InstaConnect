using InstaConnect.Common.Domain.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikesPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
