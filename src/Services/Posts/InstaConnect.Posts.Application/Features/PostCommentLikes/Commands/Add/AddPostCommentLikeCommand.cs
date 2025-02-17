namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

public record AddPostCommentLikeCommand(string CurrentUserId, string PostCommentId) : ICommand<PostCommentLikeCommandViewModel>;
