namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesSortTermUserNameDataAttribute
    : SortEnumDataAttribute<PostLikesSortTerm>
{
    public PostLikesSortTermUserNameDataAttribute()
        : base(PostLikesSortTerm.ByUserName)
    {
    }
}
