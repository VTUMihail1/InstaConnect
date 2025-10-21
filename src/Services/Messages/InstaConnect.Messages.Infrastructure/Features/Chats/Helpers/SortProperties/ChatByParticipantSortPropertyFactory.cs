using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Common.Infrastructure.ChatSortPropertys;
internal class ChatByParticipantSortPropertyFactory : IChatByParticipantSortPropertyFactory
{
    private readonly IEnumerable<IChatByParticipantSortProperty> _chatByParticipantSortProperties;

    public ChatByParticipantSortPropertyFactory(IEnumerable<IChatByParticipantSortProperty> chatByParticipantSortProperties)
    {
        _chatByParticipantSortProperties = chatByParticipantSortProperties;
    }

    public IChatByParticipantSortProperty Create(ChatByParticipantSortProperty sortProperty)
    {
        var property = _chatByParticipantSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new ChatByParticipantSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
