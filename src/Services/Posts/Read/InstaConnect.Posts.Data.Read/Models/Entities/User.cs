﻿using InstaConnect.Posts.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data.Read.Models.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public ICollection<Post> Posts { get; set; } = new List<Post>();

    public ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

    public ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public ICollection<PostCommentLike> PostCommentLikes { get; set; } = new List<PostCommentLike>();
}


