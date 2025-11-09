namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentIncludeQuery(ICollection<PostCommentIncludeProperty> Properties);
