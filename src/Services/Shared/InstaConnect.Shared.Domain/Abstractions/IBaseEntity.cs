namespace InstaConnect.Shared.Data.Abstractions;

public interface IBaseEntity : IAuditableInfo
{
    string Id { get; set; }
}
