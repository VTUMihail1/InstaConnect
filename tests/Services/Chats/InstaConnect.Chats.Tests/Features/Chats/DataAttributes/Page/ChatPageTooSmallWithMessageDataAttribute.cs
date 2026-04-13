namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatPageTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public ChatPageTooSmallWithMessageDataAttribute()
        : base(ChatConfigurations.PageMinValue)
    {
    }
}

