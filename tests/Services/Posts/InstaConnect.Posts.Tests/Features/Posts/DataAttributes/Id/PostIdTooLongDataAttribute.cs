namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooLongDataAttribute : TooLongStringDataAttribute
{
	public PostIdTooLongDataAttribute()
		: base(PostConfigurations.IdMaxLength)
	{
	}
}
