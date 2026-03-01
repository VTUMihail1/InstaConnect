using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;

public record UserId(string Id) : IEntityId
{
    public bool Is(UserId id)
    {
        return Id.EqualsOrdinalIgnoreCase(id.Id);
    }

    public bool IsNot(UserId id)
    {
        return !Is(id);
    }

    public bool IsEmpty()
    {
        return Id.IsNullOrEmptyOrWhiteSpace();
    }
}
