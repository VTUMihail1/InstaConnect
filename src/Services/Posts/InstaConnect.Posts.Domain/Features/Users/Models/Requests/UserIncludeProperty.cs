namespace InstaConnect.Posts.Domain.Features.Users.Models.Requests;

public enum UserIncludeProperty
{
    None,
    Posts,
    PostLikes,
    PostComments,
    PostCommentLikes
}
