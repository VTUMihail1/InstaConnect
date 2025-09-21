using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatByParticipantSortProperty
{
    public ChatByParticipantSortProperty SortProperty { get; }

    public string Property { get; }
}
