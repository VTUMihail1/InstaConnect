using InstaConnect.Data.Abstraction.Helpers;

namespace InstaConnect.Presentation.API.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedDb(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDbSeeder>();

                await databaseInitializer.SeedAsync();
            }
        }
    }
}
