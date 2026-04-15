namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesSortTermCreatedAtDataAttribute
    : SortEnumDataAttribute<PostLikesSortTerm>
{
    public PostLikesSortTermCreatedAtDataAttribute()
        : base(PostLikesSortTerm.ByCreatedAt)
    {
    }
}
