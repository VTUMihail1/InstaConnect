﻿using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetPostCommentLikeById
{
    public class GetPostCommentLikeByIdQuery : IQuery<PostCommentLikeViewDTO>
    {
        public string Id { get; set; }
    }
}