﻿using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post
{
    public class AddPostRequestModel
    {
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}