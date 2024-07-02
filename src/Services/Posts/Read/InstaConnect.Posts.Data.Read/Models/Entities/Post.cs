﻿using InstaConnect.Messages.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Read.Models.Entities;

public class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public User User { get; set; } = new();

    public ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

    public ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();
}
