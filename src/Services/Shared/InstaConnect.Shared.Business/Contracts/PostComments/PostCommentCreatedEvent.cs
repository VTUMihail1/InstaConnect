﻿namespace InstaConnect.Shared.Business.Contracts.PostComments;

public class PostCommentCreatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
}
