namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatsSortTermWithCreatedAtTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<ChatsSortTerm, Chat, DateTimeOffset>
{
	public ChatsSortTermWithCreatedAtTermDataAttribute()
		: base(ChatsSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
	{
	}
}
