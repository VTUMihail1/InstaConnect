namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
	public PostCommentIdTooLongWithMessageDataAttribute()
		: base(PostCommentConfigurations.IdMaxLength)
	{
	}
}
