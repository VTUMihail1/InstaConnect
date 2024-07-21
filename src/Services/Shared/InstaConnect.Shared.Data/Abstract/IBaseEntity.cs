namespace InstaConnect.Shared.Data.Abstract;

public interface IBaseEntity : IAuditableInfo
{
    string Id { get; set; }
}
