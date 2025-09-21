using InstaConnect.Common.Models.Enums;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface IChatByParticipantSortPropertyFactory
{
    IChatByParticipantSortProperty Create(ChatByParticipantSortProperty sortProperty);
}
