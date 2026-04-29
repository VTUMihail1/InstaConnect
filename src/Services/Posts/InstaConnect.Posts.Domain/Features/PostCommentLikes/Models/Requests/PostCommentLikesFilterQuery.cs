namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikesFilterQuery(
	PostCommentId CommentId,
	Name UserName);
