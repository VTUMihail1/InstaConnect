namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatsSortTermCreatedAtDataAttribute
    : SortEnumDataAttribute<ChatsSortTerm>
{
    public ChatsSortTermCreatedAtDataAttribute()
        : base(ChatsSortTerm.ByCreatedAt)
    {
    }
}
