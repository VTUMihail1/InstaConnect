using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Features.Data.Extensions;

public static class ClientSessionHandleExtensions
{
    extension(IClientSessionHandle? session)
    {
        public bool IsInTransaction()
        {
            return session != null && session!.IsInTransaction;
        }

        public bool IsNotInTransaction()
        {
            return !session.IsInTransaction();
        }
    }
}
