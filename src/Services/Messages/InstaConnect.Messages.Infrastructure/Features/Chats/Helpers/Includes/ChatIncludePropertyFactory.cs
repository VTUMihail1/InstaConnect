using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Common.Infrastructure.ChatSortPropertys;
internal class ChatIncludePropertyFactory : IChatIncludePropertyFactory
{
    private readonly IEnumerable<IChatIncludeProperty> _chatIncludeProperty;

    public ChatIncludePropertyFactory(IEnumerable<IChatIncludeProperty> chatIncludeProperty)
    {
        _chatIncludeProperty = chatIncludeProperty;
    }

    public ICollection<IChatIncludeProperty> Create(ICollection<ChatIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _chatIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new ChatIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}
