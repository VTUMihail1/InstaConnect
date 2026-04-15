namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatPageSizeTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
    public ChatPageSizeTooLargeWithMessageDataAttribute()
        : base(ChatConfigurations.PageSizeMaxValue)
    {
    }
}
