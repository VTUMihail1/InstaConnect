using InstaConnect.Common.Domain.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class ClientSessionHandleExtensions
{
    public static bool IsInTransaction(this IClientSessionHandle? session)
    {
        return session.IsNotNull() && session!.IsInTransaction;
    }

    public static bool IsNotInTransaction(this IClientSessionHandle? session)
    {
        return !session.IsInTransaction();
    }
}
