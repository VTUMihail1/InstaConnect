namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

public record AddPostCommentCommand(string CurrentUserId, string PostId, string Content) : ICommand<PostCommentCommandViewModel>;
