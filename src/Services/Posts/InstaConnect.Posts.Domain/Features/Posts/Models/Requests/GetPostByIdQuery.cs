namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetPostByIdQuery(
    PostId Id,
    CurrentUserQuery CurrentUser) : ICurrentUserableQuery;
