using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;
public static class UserSetups
{
    public static IUserRepository GetUserRepository(this IServiceScope serviceScope)
    {
        var userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();

        return userRepository;
    }

    public static async Task<User?> GetUserByIdAsync(
        this IServiceScope serviceScope,
        UserId id,
        CancellationToken cancellationToken)
    {
        var userRepository = serviceScope.GetUserRepository();

        return await userRepository.GetByIdAsync(id, cancellationToken);
    }

    public static async Task AddUserAsync(
        this IServiceScope serviceScope,
        User user,
        CancellationToken cancellationToken)
    {
        var userRepository = serviceScope.GetUserRepository();

        await userRepository.AddAsync(user, cancellationToken);
    }

    public static async Task DeleteUserAsync(
        this IServiceScope serviceScope,
        User user,
        CancellationToken cancellationToken)
    {
        var userRepository = serviceScope.GetUserRepository();

        await userRepository.DeleteAsync(user, cancellationToken);
    }

    public static async Task ResetUserDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<IPostsContext>();

        await context.Users.ResetAsync(cancellationToken);
    }
}
