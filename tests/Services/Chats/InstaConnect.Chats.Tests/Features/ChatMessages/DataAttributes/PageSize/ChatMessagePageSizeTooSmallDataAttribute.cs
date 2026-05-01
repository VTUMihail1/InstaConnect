namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagePageSizeTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
	public ChatMessagePageSizeTooSmallDataAttribute()
		: base(ChatMessageConfigurations.PageSizeMinValue)
	{
	}
}

