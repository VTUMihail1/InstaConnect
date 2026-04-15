namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsSortTermCreatedAtDataAttribute
    : SortEnumDataAttribute<PostsSortTerm>
{
    public PostsSortTermCreatedAtDataAttribute()
        : base(PostsSortTerm.ByCreatedAt)
    {
    }
}
