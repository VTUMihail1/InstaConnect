﻿namespace InstaConnect.Posts.Web.Models.Responses;

public class PostCommentResponse
{
    public string UserId { get; set; }

    public string UserName { get; set; }

    public string PostId { get; set; }

    public string Content { get; set; }
}