using InstaConnect.Shared.Domain.Abstractions;

namespace InstaConnect.Shared.Domain.Models.Base;

public abstract class BaseEntity : IBaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
