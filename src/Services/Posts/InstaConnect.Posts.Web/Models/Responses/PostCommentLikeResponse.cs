﻿namespace InstaConnect.Posts.Web.Models.Responses;

public class PostCommentLikeResponse
{
    public string Id { get; set; }

    public string PostCommentId { get; set; }

    public string UserId { get; set; }

    public string UserName { get; set; }
}