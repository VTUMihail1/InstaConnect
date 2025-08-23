using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
public static class UserSetups
{
    public static IUserRepository GetUserRepository(this IServiceScope serviceScope)
    {
        var userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();

        return userRepository;
    }

    public static async Task<User?> GetUserByIdAsync(
        this IServiceScope serviceScope,
        string id,
        CancellationToken cancellationToken)
    {
        var userRepository = serviceScope.GetUserRepository();
        var user = await userRepository.GetByIdAsync(id, cancellationToken);

        return user;
    }

    public static async Task AddUserAsync(
        this IServiceScope serviceScope,
        User user,
        CancellationToken cancellationToken)
    {
        var unitOfWork = serviceScope.GetUnitOfWork();
        var userRepository = serviceScope.GetUserRepository();

        userRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public static async Task DeleteUserAsync(
        this IServiceScope serviceScope,
        User user,
        CancellationToken cancellationToken)
    {
        var unitOfWork = serviceScope.GetUnitOfWork();
        var userRepository = serviceScope.GetUserRepository();

        userRepository.Delete(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public static async Task ResetUserDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<PostsContext>();

        if (await dbContext.Users.AnyAsync(cancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(cancellationToken);
        }
    }
}
