namespace InstaConnect.Shared.Domain.Abstractions;

public interface IBaseEntity : IAuditableInfo
{
    string Id { get; set; }
}
