using InstaConnect.Posts.Domain.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

using StackExchange.Redis;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Repositories;

internal class UserCommandRepository : IUserCommandRepository
{
    private readonly IPostsContext _context;
    private readonly IUserIncluderFactory _includePropertyFactory;

    public UserCommandRepository(
        IPostsContext context,
        IUserIncluderFactory includePropertyFactory)
    {
        _context = context;
        _includePropertyFactory = includePropertyFactory;
    }

    public async Task<User?> GetByIdAsync(
        UserId id,
        UserInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includePropertyFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(
        UserId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        UserId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task<User?> GetByNameAsync(
        Name name,
        UserInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includePropertyFactory, include)
            .Match(name)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<User?> GetByNameAsync(
        Name name,
        CancellationToken cancellationToken)
    {
        return await GetByNameAsync(name, null, cancellationToken);
    }

    public async Task<bool> IsNameUniqueAsync(
        Name name,
        CancellationToken cancellationToken)
    {
        return !await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Match(name)
            .AnyAsync(cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(
        Email email,
        UserInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includePropertyFactory, include)
            .Match(email)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(
        Email email,
        CancellationToken cancellationToken)
    {
        return await GetByEmailAsync(email, null, cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(
        Email email,
        CancellationToken cancellationToken)
    {
        return !await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Match(email)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(User entity, CancellationToken cancellationToken)
    {
        await _context
            .Users
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken)
    {
        await _context
            .Users
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        await _context
            .Users
            .UpdateAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        await _context
            .Users
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
