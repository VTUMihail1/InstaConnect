﻿using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Messages.Business.Features.Messages.Queries.GetAllMessages;

public record GetAllMessagesQuery(
    string CurrentUserId,
    string ReceiverId,
    string ReceiverName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize) : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<MessagePaginationQueryViewModel>;
