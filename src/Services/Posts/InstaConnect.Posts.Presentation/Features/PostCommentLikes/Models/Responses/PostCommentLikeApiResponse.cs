using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Payloads;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeApiResponse(PostCommentLikeIdApiPayload Id, PostCommentLikeUserApiResponse User);
