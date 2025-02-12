namespace InstaConnect.Messages.Application.Features.Messages.Models;

public record MessagePaginationQueryViewModel(
    ICollection<MessageQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
