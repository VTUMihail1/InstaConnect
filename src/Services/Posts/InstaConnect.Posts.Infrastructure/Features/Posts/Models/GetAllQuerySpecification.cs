namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetAllQuerySpecification(string Sql, Func<Post, User, Post> Map, GetAllQueryParameters Parameters, string SplitOn);
