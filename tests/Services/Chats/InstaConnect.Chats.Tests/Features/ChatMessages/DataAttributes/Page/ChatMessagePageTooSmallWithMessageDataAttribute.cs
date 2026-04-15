namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagePageTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public ChatMessagePageTooSmallWithMessageDataAttribute()
        : base(ChatMessageConfigurations.PageMinValue)
    {
    }
}

