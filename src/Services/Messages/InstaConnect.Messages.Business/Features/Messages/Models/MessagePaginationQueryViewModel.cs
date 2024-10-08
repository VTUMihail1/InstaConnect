﻿namespace InstaConnect.Messages.Business.Features.Messages.Models;

public record MessagePaginationQueryViewModel(
    ICollection<MessageQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
