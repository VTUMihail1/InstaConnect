﻿using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.Posts.Models.Requests;

public class DeletePostRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}