﻿using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Messages.Business.Queries.Messages.GetMessageById;

public class GetMessageByIdQuery : IQuery<MessageViewDTO>
{
    public string Id { get; set; }
}