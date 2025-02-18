namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

public record AddPostLikeCommand(string CurrentUserId, string PostId) : ICommand<PostLikeCommandViewModel>;
