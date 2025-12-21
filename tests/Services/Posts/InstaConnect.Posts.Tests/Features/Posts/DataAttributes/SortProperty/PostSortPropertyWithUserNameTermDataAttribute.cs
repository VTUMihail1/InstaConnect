using InstaConnect.Common.Domain.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortPropertyWithUserNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostSortProperty, Post, string>
{
    public PostSortPropertyWithUserNameTermDataAttribute()
        : base(PostSortProperty.ByUserName, p => p.User!.Name.Value)
    {
    }
}
