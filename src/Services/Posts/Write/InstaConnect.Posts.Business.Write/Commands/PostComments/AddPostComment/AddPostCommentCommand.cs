﻿using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Write.Commands.PostComments.AddPostComment;

public class AddPostCommentCommand : ICommand
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
