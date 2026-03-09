using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserSetups
{
    extension(IServiceScope serviceScope)
    {
        public IUserCommandRepository GetUserCommandRepository()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IUserCommandRepository>();
        }

        public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IUserIncludeBuilderFactory>();
        }

        public async Task<User?> GetUserByIdAsync(
            UserId id,
            CancellationToken cancellationToken)
        {
            var userRepository = serviceScope.GetUserCommandRepository();

            return await userRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task AddUserAsync(
            User user,
            CancellationToken cancellationToken)
        {
            var userRepository = serviceScope.GetUserCommandRepository();

            await userRepository.AddAsync(user, cancellationToken);
        }

        public async Task AddUserRangeAsync(
            IEnumerable<User> users,
            CancellationToken cancellationToken)
        {
            var userRepository = serviceScope.GetUserCommandRepository();

            await userRepository.AddRangeAsync(users, cancellationToken);
        }

        public async Task DeleteUserAsync(
            User user,
            CancellationToken cancellationToken)
        {
            var userRepository = serviceScope.GetUserCommandRepository();

            await userRepository.DeleteAsync(user, cancellationToken);
        }

        public async Task ResetUserDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<IIdentityContext>();

            await context.Users.ResetAsync(cancellationToken);
        }
    }
}
