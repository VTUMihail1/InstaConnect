namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatPageTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
	public ChatPageTooLargeWithMessageDataAttribute()
		: base(ChatConfigurations.PageMaxValue)
	{
	}
}

