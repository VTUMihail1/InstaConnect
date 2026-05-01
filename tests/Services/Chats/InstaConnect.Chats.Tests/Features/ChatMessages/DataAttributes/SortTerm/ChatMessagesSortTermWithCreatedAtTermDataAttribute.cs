namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagesSortTermWithCreatedAtTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<ChatMessagesSortTerm, ChatMessage, DateTimeOffset>
{
	public ChatMessagesSortTermWithCreatedAtTermDataAttribute()
		: base(ChatMessagesSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
	{
	}
}
