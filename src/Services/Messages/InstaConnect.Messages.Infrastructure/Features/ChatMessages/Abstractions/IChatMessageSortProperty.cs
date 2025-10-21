using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageSortProperty
{
    public ChatMessageSortProperty SortProperty { get; }

    public Expression<Func<ChatMessage, object>> Property { get; }
}
