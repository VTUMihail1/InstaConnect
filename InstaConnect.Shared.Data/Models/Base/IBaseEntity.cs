namespace InstaConnect.Shared.Data.Models.Base
{
    /// <summary>
    /// Represents a base entity abstraction.
    /// </summary>
    public interface IBaseEntity : IAuditableInfo
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        string Id { get; set; }
    }
}
