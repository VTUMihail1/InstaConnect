using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikeIncludeQuery(ICollection<PostLikeIncludeProperty> Properties);
