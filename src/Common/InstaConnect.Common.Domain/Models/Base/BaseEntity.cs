using InstaConnect.Shared.Domain.Abstractions;

namespace InstaConnect.Shared.Domain.Models.Base;

public abstract class BaseEntity : IBaseEntity, IAuditableInfo
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}
