namespace InstaConnect.Posts.Domain.Models.Requests;

public enum PostsIncludeType
{
    None,
    User,
    Post,
    PostLike,
    PostComment,
    PostCommentLike
}
