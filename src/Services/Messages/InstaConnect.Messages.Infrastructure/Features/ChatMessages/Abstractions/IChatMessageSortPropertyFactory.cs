using InstaConnect.Common.Models.Enums;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface IChatMessageSortPropertyFactory
{
    IChatMessageSortProperty Create(ChatMessageSortProperty sortProperty);
}
