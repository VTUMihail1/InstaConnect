using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagesSortOrderWithDescendingTermDataAttribute
	: SortEnumWithDescendingTermDataAttribute<CommonSortOrder, ChatMessage, DateTimeOffset>
{
	public ChatMessagesSortOrderWithDescendingTermDataAttribute()
		: base(CommonSortOrder.Descending, p => p.CreatedAtUtc)
	{
	}
}
