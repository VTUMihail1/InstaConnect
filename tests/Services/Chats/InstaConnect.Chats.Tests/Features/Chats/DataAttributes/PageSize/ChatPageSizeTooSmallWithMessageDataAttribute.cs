namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatPageSizeTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public ChatPageSizeTooSmallWithMessageDataAttribute()
        : base(ChatConfigurations.PageSizeMinValue)
    {
    }
}
