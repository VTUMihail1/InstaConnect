namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageContentNullWithMessageDataAttribute : NullStringWithMessageDataAttribute;

