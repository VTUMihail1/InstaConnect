﻿using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Write.Models.Requests.PostLike;

public class DeletePostLikeRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
