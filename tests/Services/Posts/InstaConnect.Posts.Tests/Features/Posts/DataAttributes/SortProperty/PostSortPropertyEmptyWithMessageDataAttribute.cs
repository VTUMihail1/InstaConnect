namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortPropertyEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<PostSortProperty>
{
    public PostSortPropertyEmptyWithMessageDataAttribute()
        : base(PostErrorMessages.GetSortPropertyEmpty())
    {
    }
}
