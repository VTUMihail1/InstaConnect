namespace InstaConnect.Data.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for seeding a database with initial data asynchronously.
    /// </summary>
    /// <remarks>
    /// Implement this interface to define a mechanism for populating a database with initial data asynchronously.
    /// The <see cref="SeedAsync"/> method should be implemented to perform the data seeding operation.
    /// </remarks>
    public interface IDbSeeder
    {
        /// <summary>
        /// Seeds the database with initial data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SeedAsync();

        Task ApplyPendingMigrationsAsync();
    }
}