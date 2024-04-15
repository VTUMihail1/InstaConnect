namespace InstaConnect.Data.Models.Entities.Base
{
    /// <summary>
    /// Represents an interface for entities that track creation and update timestamps.
    /// </summary>
    public interface IAuditableInfo
    {
        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was last updated.
        /// </summary>
        DateTime UpdatedAt { get; set; }
    }
}
