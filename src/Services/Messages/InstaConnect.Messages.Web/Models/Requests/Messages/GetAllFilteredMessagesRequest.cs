﻿using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Models.Requests.Messages;

public class GetAllFilteredMessagesRequest : CollectionReadRequest
{
    [FromQuery(Name = "receiverId")]
    public string ReceiverId { get; set; } = string.Empty;

    [FromQuery(Name = "receiverName")]
    public string ReceiverName { get; set; } = string.Empty;
}