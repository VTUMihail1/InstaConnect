﻿using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostComment
{
    public class GetPostCommentsCollectionRequestModel : CollectionRequestModel
    {
        [FromQuery(Name = "userId")]
        public string UserId { get; set; } = string.Empty;

        [FromQuery(Name = "postId")]
        public string PostId { get; set; } = string.Empty;

        [FromQuery(Name = "postCommentId")]
        public string? PostCommentId { get; set; }
    }
}
