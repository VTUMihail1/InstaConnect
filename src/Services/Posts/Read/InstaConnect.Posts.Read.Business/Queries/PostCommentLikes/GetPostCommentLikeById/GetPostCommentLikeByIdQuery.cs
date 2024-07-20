﻿using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetPostCommentLikeById;

public class GetPostCommentLikeByIdQuery : IQuery<PostCommentLikeViewModel>
{
    public string Id { get; set; } = string.Empty;
}