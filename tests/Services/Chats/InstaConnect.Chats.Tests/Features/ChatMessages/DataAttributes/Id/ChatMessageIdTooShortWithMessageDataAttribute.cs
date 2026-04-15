namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageIdTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
    public ChatMessageIdTooShortWithMessageDataAttribute()
        : base(ChatMessageConfigurations.IdMinLength)
    {
    }
}
