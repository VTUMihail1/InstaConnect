namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

public record UpdatePostCommentCommand(string Id, string PostId, string CurrentUserId, string Content) : ICommand<PostCommentCommandViewModel>;
