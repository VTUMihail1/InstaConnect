namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagePageTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
    public ChatMessagePageTooSmallDataAttribute()
        : base(ChatMessageConfigurations.PageMinValue)
    {
    }
}

