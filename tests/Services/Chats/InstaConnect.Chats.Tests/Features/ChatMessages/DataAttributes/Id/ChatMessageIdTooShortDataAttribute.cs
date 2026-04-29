namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageIdTooShortDataAttribute : TooShortStringDataAttribute
{
	public ChatMessageIdTooShortDataAttribute()
		: base(ChatMessageConfigurations.IdMinLength)
	{
	}
}
