namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatPageSizeTooLargeDataAttribute : TooLargeIntDataAttribute
{
    public ChatPageSizeTooLargeDataAttribute()
        : base(ChatConfigurations.PageSizeMaxValue)
    {
    }
}

