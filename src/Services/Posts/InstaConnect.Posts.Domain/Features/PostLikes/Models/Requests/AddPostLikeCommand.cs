namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record AddPostLikeCommand(PostId Id, UserId UserId);
