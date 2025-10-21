using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatByParticipantSortProperty
{
    public ChatByParticipantSortProperty SortProperty { get; }

    public Expression<Func<Chat, object>> Property { get; }
}
