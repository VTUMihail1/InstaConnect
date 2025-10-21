using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Exceptions;

namespace InstaConnect.Common.Infrastructure.ChatMessageSortPropertys;
internal class ChatMessageIncludePropertyFactory : IChatMessageIncludePropertyFactory
{
    private readonly IEnumerable<IChatMessageIncludeProperty> _chatMessageIncludeProperty;

    public ChatMessageIncludePropertyFactory(IEnumerable<IChatMessageIncludeProperty> chatMessageIncludeProperty)
    {
        _chatMessageIncludeProperty = chatMessageIncludeProperty;
    }

    public ICollection<IChatMessageIncludeProperty> Create(ICollection<ChatMessageIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _chatMessageIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new ChatMessageIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}
