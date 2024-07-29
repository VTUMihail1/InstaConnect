using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Shared.Data.Models.Base;

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
