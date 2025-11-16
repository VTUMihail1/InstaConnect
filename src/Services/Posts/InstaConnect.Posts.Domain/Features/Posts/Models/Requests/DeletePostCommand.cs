namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record DeletePostCommand(
    PostId Id,
    UserId UserId);
