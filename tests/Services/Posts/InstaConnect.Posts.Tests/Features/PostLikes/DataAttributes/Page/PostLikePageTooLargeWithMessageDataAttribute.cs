namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
    public PostLikePageTooLargeWithMessageDataAttribute()
        : base(PostLikeConfigurations.PageMaxValue)
    {
    }
}

