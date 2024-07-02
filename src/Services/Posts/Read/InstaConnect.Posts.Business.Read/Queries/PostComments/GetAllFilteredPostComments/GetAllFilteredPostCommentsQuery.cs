﻿using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllFilteredPostComments;

public class GetAllFilteredPostCommentsQuery : CollectionModel, IQuery<ICollection<PostCommentViewModel>>
{
    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;
}
