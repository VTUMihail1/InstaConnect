using InstaConnect.Common.Domain.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatsPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
