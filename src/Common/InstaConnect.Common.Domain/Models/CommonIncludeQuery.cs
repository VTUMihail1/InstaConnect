namespace InstaConnect.Common.Domain.Models;

public record CommonIncludeQuery<TIncludeProperty>(ICollection<TIncludeProperty> Properties)
    where TIncludeProperty : Enum;
