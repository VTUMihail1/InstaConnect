namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record AddPostCommentCommand(string Id, string Content, string UserId);
