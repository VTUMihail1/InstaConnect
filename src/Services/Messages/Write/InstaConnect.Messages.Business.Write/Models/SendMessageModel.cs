﻿namespace InstaConnect.Messages.Business.Write.Models;

public class SendMessageModel
{
    public string ReceiverId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
