﻿namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

public record DeletePostLikeCommand(string Id, string PostId, string CurrentUserId) : ICommand;
