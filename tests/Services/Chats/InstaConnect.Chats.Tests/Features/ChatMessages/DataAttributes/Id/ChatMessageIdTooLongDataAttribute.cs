namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageIdTooLongDataAttribute : TooLongStringDataAttribute
{
    public ChatMessageIdTooLongDataAttribute()
        : base(ChatMessageConfigurations.IdMaxLength)
    {
    }
}
