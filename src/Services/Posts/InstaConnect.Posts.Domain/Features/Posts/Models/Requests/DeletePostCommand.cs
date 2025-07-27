namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record DeletePostCommand(
    string Id,
    string CurrentUserId);
