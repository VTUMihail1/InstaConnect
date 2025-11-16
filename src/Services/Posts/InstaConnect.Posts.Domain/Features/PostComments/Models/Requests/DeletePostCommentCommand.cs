namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record DeletePostCommentCommand(
    PostCommentId Id,
    UserId UserId);
