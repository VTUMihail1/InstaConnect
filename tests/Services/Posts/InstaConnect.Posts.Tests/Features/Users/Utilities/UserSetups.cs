using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserSetups
{
    extension(IServiceProvider serviceProvider)
    {
        public IUserCommandRepository GetUserCommandRepository()
        {
            return serviceProvider.GetRequiredService<IUserCommandRepository>();
        }

        public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
        {
            return serviceProvider.GetRequiredService<IUserIncludeBuilderFactory>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IUserCommandRepository GetUserCommandRepository()
        {
            return serviceScope.ServiceProvider.GetUserCommandRepository();
        }

        public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetUserIncludeBuilderFactory();
        }

        public async Task<User?> GetUserByIdAsync(
            UserId id,
            CancellationToken cancellationToken)
        {
            return await serviceScope.GetUserCommandRepository().GetByIdAsync(id, cancellationToken);
        }

        public async Task AddUserAsync(
            User user,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetUserCommandRepository().AddAsync(user, cancellationToken);
        }

        public async Task AddUserRangeAsync(
            IEnumerable<User> users,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetUserCommandRepository().AddRangeAsync(users, cancellationToken);
        }

        public async Task DeleteUserAsync(
            User user,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetUserCommandRepository().DeleteAsync(user, cancellationToken);
        }
    }
}
