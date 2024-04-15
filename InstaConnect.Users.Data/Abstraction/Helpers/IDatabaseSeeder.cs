namespace InstaConnect.Users.Data.Abstraction.Helpers
{
    /// <summary>
    /// Provides methods for seeding a database and applying pending migrations.
    /// </summary>
    public interface IDatabaseSeeder
    {
        /// <summary>
        /// Asynchronously seeds data into the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous seeding operation.</returns>
        Task SeedAsync();

        /// <summary>
        /// Asynchronously applies pending database migrations.
        /// </summary>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        Task ApplyPendingMigrationsAsync();
    }
}