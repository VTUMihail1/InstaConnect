using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeIdPayload(PostCommentIdPayload CommentId, UserIdPayload UserId);
