namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdTooLongDataAttribute : TooLongStringDataAttribute
{
	public PostCommentIdTooLongDataAttribute()
		: base(PostCommentConfigurations.IdMaxLength)
	{
	}
}
