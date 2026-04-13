namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatsSortTermWithParticipantTwoNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<ChatsSortTerm, Chat, string>
{
    public ChatsSortTermWithParticipantTwoNameTermDataAttribute()
        : base(ChatsSortTerm.ByParticipantTwoName, p => p.ParticipantTwo!.Name.Value)
    {
    }
}
