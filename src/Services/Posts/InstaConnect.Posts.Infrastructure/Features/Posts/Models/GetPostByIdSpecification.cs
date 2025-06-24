namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetPostByIdSpecification(string Sql, Func<Post, User, Post> Map, GetPostByIdParameters Parameters, string SplitOn);
