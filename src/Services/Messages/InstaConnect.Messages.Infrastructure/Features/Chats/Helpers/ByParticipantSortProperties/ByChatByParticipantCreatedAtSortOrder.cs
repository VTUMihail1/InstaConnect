using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Chats.Helpers.SortProperties;
public class ByChatByParticipantCreatedAtSortOrder : IChatByParticipantSortProperty
{
    public ChatByParticipantSortProperty SortProperty => ChatByParticipantSortProperty.ByCreatedAt;

    public string Property => ChatByParticipantSortPropertyUtilities.ByCreatedAt;
}
