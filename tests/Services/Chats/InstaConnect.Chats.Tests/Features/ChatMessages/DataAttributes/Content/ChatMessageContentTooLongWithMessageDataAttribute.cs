namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageContentTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
	public ChatMessageContentTooLongWithMessageDataAttribute()
		: base(ChatMessageConfigurations.ContentMaxLength)
	{
	}
}

