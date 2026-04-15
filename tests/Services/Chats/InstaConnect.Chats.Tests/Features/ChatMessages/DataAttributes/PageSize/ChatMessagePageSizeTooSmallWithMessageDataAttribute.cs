namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagePageSizeTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public ChatMessagePageSizeTooSmallWithMessageDataAttribute()
        : base(ChatMessageConfigurations.PageSizeMinValue)
    {
    }
}
