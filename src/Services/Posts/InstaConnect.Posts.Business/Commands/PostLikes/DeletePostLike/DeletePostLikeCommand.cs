﻿using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostLikes.DeletePostLike;

public class DeletePostLikeCommand : ICommand
{
    public string Id { get; set; }
}
