namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Abstractions;
public interface IUsersClient
{
    Task<UserCommandResponse> AddAsync(AddUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddUserRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteUserRequest request, CancellationToken cancellationToken);
    Task DeleteCurrentAsync(DeleteCurrentUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteCurrentStatusCodeAsync(DeleteCurrentUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteCurrentStatusCodeUnauthorizedAsync(DeleteCurrentUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeleteUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(DeleteUserRequest request, CancellationToken cancellationToken);
    Task<UserPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken);
    Task<UserPaginationQueryResponse> GetAllAsync(GetAllUsersRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllUsersRequest request, CancellationToken cancellationToken);
    Task<UserQueryResponse> GetByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetUserByIdRequest request, CancellationToken cancellationToken);
    Task<UserQueryResponse> GetByNameAsync(GetUserByNameRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByNameStatusCodeAsync(GetUserByNameRequest request, CancellationToken cancellationToken);
    Task<UserQueryResponse> GetCurrentAsync(GetCurrentUserRequest request, CancellationToken cancellationToken);
    Task<UserDetailedQueryResponse> GetCurrentDetailedAsync(GetCurrentDetailedUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetCurrentDetailedStatusCodeAsync(GetCurrentDetailedUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetCurrentDetailedStatusCodeUnauthorizedAsync(GetCurrentDetailedUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetCurrentStatusCodeAsync(GetCurrentUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetCurrentStatusCodeUnauthorizedAsync(GetCurrentUserRequest request, CancellationToken cancellationToken);
    Task<UserDetailedQueryResponse> GetDetailedByIdAsync(GetDetailedUserByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetDetailedByIdStatusCodeAsync(GetDetailedUserByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetDetailedByIdStatusCodeUnathorizedAsync(GetDetailedUserByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetDetailedByIdStatusCodeNonAdminAsync(GetDetailedUserByIdRequest request, CancellationToken cancellationToken);
    Task<UserTokenCommandResponse> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> LoginStatusCodeAsync(LoginUserRequest request, CancellationToken cancellationToken);
    Task<UserCommandResponse> UpdateCurrentAsync(UpdateCurrentUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateCurrentStatusCodeAsync(UpdateCurrentUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateCurrentStatusCodeUnauthorizedAsync(UpdateCurrentUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeNonAdminAsync(DeleteUserRequest request, CancellationToken cancellationToken);
}
