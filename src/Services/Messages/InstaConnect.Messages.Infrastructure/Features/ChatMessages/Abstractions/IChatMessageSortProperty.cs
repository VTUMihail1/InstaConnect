using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageSortProperty
{
    public ChatMessageSortProperty SortProperty { get; }

    public string Property { get; }
}
