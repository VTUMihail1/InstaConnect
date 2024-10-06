using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Models.Filters;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Data.Features.Users.Repositories;

internal class UserReadRepository : IUserReadRepository
{
    private readonly IdentityContext _identityContext;

    public UserReadRepository(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<PaginationList<User>> GetAllAsync(UserCollectionReadQuery query, CancellationToken cancellationToken)
    {
        var entities = await _identityContext
            .Users
            .Where(u => (string.IsNullOrEmpty(query.UserName) || u.UserName.StartsWith(query.UserName)) &&
                        (string.IsNullOrEmpty(query.FirstName) || u.FirstName.StartsWith(query.FirstName)) &&
                        (string.IsNullOrEmpty(query.LastName) || u.LastName.StartsWith(query.LastName)))
            .OrderEntities(query.SortOrder, query.SortPropertyName)
            .ToPagedListAsync(query.Page, query.PageSize, cancellationToken);

        return entities;
    }

    public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var entity = await _identityContext
            .Users
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var entity = await _identityContext
            .Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        return entity;
    }

    public async Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        var entity = await _identityContext
            .Users
            .FirstOrDefaultAsync(u => u.UserName == name, cancellationToken);

        return entity;
    }
}
