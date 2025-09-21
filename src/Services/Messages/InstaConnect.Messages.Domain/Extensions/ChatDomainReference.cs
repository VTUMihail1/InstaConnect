using System.Reflection;

namespace InstaConnect.Chats.Domain.Extensions;
public static class ChatDomainReference
{
    public static readonly Assembly Assembly = typeof(ChatDomainReference).Assembly;
}
