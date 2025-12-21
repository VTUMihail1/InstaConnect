namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeSortPropertyUserNameDataAttribute
    : SortEnumDataAttribute<PostLikeSortProperty>
{
    public PostLikeSortPropertyUserNameDataAttribute()
        : base(PostLikeSortProperty.ByUserName)
    {
    }
}
