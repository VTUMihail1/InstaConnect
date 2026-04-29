namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatPageSizeTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
	public ChatPageSizeTooSmallDataAttribute()
		: base(ChatConfigurations.PageSizeMinValue)
	{
	}
}

