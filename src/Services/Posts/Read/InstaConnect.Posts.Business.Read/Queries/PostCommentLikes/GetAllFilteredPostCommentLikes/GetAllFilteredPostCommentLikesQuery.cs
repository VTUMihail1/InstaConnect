﻿using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

public class GetAllFilteredPostCommentLikesQuery : CollectionModel, IQuery<ICollection<PostCommentLikeViewModel>>
{
    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string PostCommentId { get; set; } = string.Empty;
}
