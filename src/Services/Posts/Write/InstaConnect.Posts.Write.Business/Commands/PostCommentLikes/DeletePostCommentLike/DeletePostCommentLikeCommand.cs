﻿using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Write.Business.Commands.PostCommentLikes.DeletePostCommentLike;

public class DeletePostCommentLikeCommand : ICommand
{
    public string Id { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;
}