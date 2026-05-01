namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagePageSizeTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
	public ChatMessagePageSizeTooLargeWithMessageDataAttribute()
		: base(ChatMessageConfigurations.PageSizeMaxValue)
	{
	}
}
