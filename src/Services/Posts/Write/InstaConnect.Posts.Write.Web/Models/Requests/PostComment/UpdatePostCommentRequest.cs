﻿using InstaConnect.Posts.Write.Web.Models.Binding.PostComments;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Write.Web.Models.Requests.PostComment;

public class UpdatePostCommentRequest
{
    [FromRoute]
    public string PostId { get; set; } = string.Empty;

    [FromBody]
    public UpdatePostCommentBindingModel UpdatePostCommentBindingModel { get; set; } = new();
}