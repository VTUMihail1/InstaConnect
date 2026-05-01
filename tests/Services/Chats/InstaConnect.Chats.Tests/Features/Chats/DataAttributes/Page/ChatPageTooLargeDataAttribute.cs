namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatPageTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public ChatPageTooLargeDataAttribute()
		: base(ChatConfigurations.PageMaxValue)
	{
	}
}

