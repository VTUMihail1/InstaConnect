namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatsSortTermParticipantTwoNameDataAttribute
	: SortEnumDataAttribute<ChatsSortTerm>
{
	public ChatsSortTermParticipantTwoNameDataAttribute()
		: base(ChatsSortTerm.ByParticipantTwoName)
	{
	}
}
