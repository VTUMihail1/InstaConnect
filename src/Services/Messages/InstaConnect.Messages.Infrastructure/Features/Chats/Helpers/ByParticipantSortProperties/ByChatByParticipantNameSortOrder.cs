using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Chats.Helpers.SortProperties;

public class ByChatByParticipantNameSortOrder : IChatByParticipantSortProperty
{
    public ChatByParticipantSortProperty SortProperty => ChatByParticipantSortProperty.ByParticipantName;

    public string Property => ChatByParticipantSortPropertyUtilities.ByParticipant;
}
