using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Common.Infrastructure.ChatMessageSortPropertys;
internal class ChatMessageSortPropertyFactory : IChatMessageSortPropertyFactory
{
    private readonly IEnumerable<IChatMessageSortProperty> _chatMessageSortProperties;

    public ChatMessageSortPropertyFactory(IEnumerable<IChatMessageSortProperty> chatMessageSortProperties)
    {
        _chatMessageSortProperties = chatMessageSortProperties;
    }

    public IChatMessageSortProperty Create(ChatMessageSortProperty sortProperty)
    {
        var property = _chatMessageSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new ChatMessageSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
