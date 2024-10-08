﻿using InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Requests;

public class AddPostCommentLikeRequest
{
    [FromBody]
    public AddPostCommentLikeBindingModel AddPostCommentLikeBindingModel { get; set; } = new(string.Empty);
}
