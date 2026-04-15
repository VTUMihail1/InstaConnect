namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatPageTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
    public ChatPageTooSmallDataAttribute()
        : base(ChatConfigurations.PageMinValue)
    {
    }
}

