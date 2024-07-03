﻿using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Write.Business.Commands.PostLikes.AddPostLike;

public class AddPostLikeCommand : ICommand
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;
}