namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
	public PostContentTooShortWithMessageDataAttribute()
		: base(PostConfigurations.ContentMinLength)
	{
	}
}

