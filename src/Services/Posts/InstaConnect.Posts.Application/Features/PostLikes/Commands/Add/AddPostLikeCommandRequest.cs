namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

public record AddPostLikeCommandRequest(string CurrentUserId, string PostId) : ICommandRequest<PostLikeCommandViewModel>;
