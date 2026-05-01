namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageIdTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
	public ChatMessageIdTooLongWithMessageDataAttribute()
		: base(ChatMessageConfigurations.IdMaxLength)
	{
	}
}
