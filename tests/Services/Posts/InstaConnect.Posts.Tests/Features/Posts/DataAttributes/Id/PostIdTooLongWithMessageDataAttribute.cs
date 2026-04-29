namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
	public PostIdTooLongWithMessageDataAttribute()
		: base(PostConfigurations.IdMaxLength)
	{
	}
}
