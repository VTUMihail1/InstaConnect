﻿using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Domain.Models.Base;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;

public class Post : BaseEntity
{
    public Post(
        string title,
        string content,
        string userId)
    {
        Title = title;
        Content = content;
        UserId = userId;
    }

    public Post(
        string title,
        string content,
        User user)
    {
        Title = title;
        Content = content;
        User = user;
        UserId = user.Id;
    }

    public string Title { get; set; }

    public string Content { get; set; }

    public string UserId { get; }

    public User? User { get; set; }

    public ICollection<PostLike> PostLikes { get; set; } = [];

    public ICollection<PostComment> PostComments { get; set; } = [];
}
