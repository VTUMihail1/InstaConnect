namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

internal class UserQueryService : IUserQueryService
{
    private readonly IUserQueryRepository _repository;
    private readonly IUserCollectionResponseFactory _collectionResponseFactory;

    public UserQueryService(
        IUserQueryRepository repository,
        IUserCollectionResponseFactory collectionResponseFactory)
    {
        _repository = repository;
        _collectionResponseFactory = collectionResponseFactory;
    }

    public async Task<UserCollectionResponse> GetAllAsync(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync(
            query.Filter,
            query.Current,
            query.Sorting,
            query.Pagination,
            cancellationToken);

        var totalCount = await _repository.GetTotalCountAsync(query.Filter, cancellationToken);

        return _collectionResponseFactory.Create(users, totalCount, query.Pagination);
    }

    public async Task<UserResponse> GetByIdAsync(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(
            query.Id,
            query.Current,
            cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(query.Id);
        }

        return user;
    }
}
