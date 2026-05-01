namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagePageTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
	public ChatMessagePageTooLargeWithMessageDataAttribute()
		: base(ChatMessageConfigurations.PageMaxValue)
	{
	}
}

