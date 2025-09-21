using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Common.Models.Enums;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.ChatMessages.Helpers.SortProperties;
public class ByChatMessageCreatedAtSortOrder : IChatMessageSortProperty
{
    public ChatMessageSortProperty SortProperty => ChatMessageSortProperty.ByCreatedAt;

    public string Property => ChatMessageSortPropertyUtilities.ByCreatedAt;
}
