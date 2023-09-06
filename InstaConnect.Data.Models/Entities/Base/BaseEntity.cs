namespace DocConnect.Data.Models.Entities.Base
{
    /// <summary>
    /// Represents a base entity class that includes audit information for creation and update timestamps.
    /// </summary>
    public abstract class BaseEntity : IAuditableInfo
    {
        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
