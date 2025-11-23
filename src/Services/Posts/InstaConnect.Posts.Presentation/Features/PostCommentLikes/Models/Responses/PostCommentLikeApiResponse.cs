using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Payloads;
using InstaConnect.Posts.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeApiResponse(PostCommentLikeIdApiPayload Id, UserApiResponse User);
