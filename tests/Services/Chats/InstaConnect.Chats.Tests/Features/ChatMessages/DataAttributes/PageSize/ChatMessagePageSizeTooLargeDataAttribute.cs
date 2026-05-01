namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagePageSizeTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public ChatMessagePageSizeTooLargeDataAttribute()
		: base(ChatMessageConfigurations.PageSizeMaxValue)
	{
	}
}

