namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagePageTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public ChatMessagePageTooLargeDataAttribute()
		: base(ChatMessageConfigurations.PageMaxValue)
	{
	}
}

