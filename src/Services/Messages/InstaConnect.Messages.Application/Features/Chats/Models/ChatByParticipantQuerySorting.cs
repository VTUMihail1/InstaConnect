using InstaConnect.Common.Models.Enums;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Chats.Models;

public record ChatByParticipantQuerySorting(
    SortOrder Order,
    ChatByParticipantSortProperty Property);
