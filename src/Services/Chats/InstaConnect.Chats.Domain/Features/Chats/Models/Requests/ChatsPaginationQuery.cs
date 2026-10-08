using InstaConnect.Common.Domain.Features.Requests.Abstractions;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatsPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
