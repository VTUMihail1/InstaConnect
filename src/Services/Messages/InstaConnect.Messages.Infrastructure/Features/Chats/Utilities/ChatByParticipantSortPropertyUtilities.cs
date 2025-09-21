using InstaConnect.Chats.Infrastructure.Features.Chats.Models;

namespace InstaConnect.Common.Infrastructure.SortOrders;
internal static class ChatByParticipantSortPropertyUtilities
{
    public const string ByCreatedAt = nameof(ChatQueryEntity.CreatedAt);

    public const string ByParticipant = nameof(ChatQueryEntity.ParticipantTwoName);
}
