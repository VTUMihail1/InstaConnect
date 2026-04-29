namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserCommandRepository
{
	public Task<User?> GetByIdAsync(
        UserId id,
        UserInclude? include,
        CancellationToken cancellationToken);

	public Task<User?> GetByIdAsync(
        UserId id,
        CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
        UserId id,
        CancellationToken cancellationToken);

    public Task<User?> GetByNameAsync(
        Name name,
        UserInclude? include,
        CancellationToken cancellationToken);

    public Task<User?> GetByNameAsync(
        Name name,
        CancellationToken cancellationToken);

    public Task<bool> IsNameUniqueAsync(
        Name name,
        CancellationToken cancellationToken);

    public Task<User?> GetByEmailAsync(
        Email email,
        UserInclude? include,
        CancellationToken cancellationToken);

    public Task<User?> GetByEmailAsync(
        Email email,
        CancellationToken cancellationToken);

    public Task<bool> IsEmailUniqueAsync(
        Email email,
        CancellationToken cancellationToken);

    public Task AddAsync(User entity, CancellationToken cancellationToken);

    public Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken);

    public Task DeleteAsync(User entity, CancellationToken cancellationToken);

    public Task UpdateAsync(User entity, CancellationToken cancellationToken);
}
