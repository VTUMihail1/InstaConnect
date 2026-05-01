namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagesSortTermEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<ChatMessagesSortTerm>;
