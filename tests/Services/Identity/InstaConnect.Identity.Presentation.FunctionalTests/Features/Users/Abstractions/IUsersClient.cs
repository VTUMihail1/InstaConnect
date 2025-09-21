namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Abstractions;
public interface IUsersClient
{
    Task<UserCommandResponse> AddAsync(AddUserApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddUserApiRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteUserApiRequest request, CancellationToken cancellationToken);
    Task DeleteCurrentAsync(DeleteCurrentUserApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteCurrentStatusCodeAsync(DeleteCurrentUserApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteCurrentStatusCodeUnauthorizedAsync(DeleteCurrentUserApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeleteUserApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(DeleteUserApiRequest request, CancellationToken cancellationToken);
    Task<UserPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken);
    Task<UserPaginationQueryResponse> GetAllAsync(GetAllUsersApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllUsersApiRequest request, CancellationToken cancellationToken);
    Task<UserQueryResponse> GetByIdAsync(GetUserByIdApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetUserByIdApiRequest request, CancellationToken cancellationToken);
    Task<UserQueryResponse> GetByNameAsync(GetUserByNameRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByNameStatusCodeAsync(GetUserByNameRequest request, CancellationToken cancellationToken);
    Task<UserQueryResponse> GetCurrentAsync(GetCurrentUserByIdApiRequest request, CancellationToken cancellationToken);
    Task<UserDetailedQueryResponse> GetCurrentDetailedAsync(GetCurrentUserDetailsApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetCurrentDetailedStatusCodeAsync(GetCurrentUserDetailsApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetCurrentDetailedStatusCodeUnauthorizedAsync(GetCurrentUserDetailsApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetCurrentStatusCodeAsync(GetCurrentUserByIdApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetCurrentStatusCodeUnauthorizedAsync(GetCurrentUserByIdApiRequest request, CancellationToken cancellationToken);
    Task<UserDetailedQueryResponse> GetDetailedByIdAsync(GetUserDetailsByIdApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetDetailedByIdStatusCodeAsync(GetUserDetailsByIdApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetDetailedByIdStatusCodeUnathorizedAsync(GetUserDetailsByIdApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetDetailedByIdStatusCodeNonAdminAsync(GetUserDetailsByIdApiRequest request, CancellationToken cancellationToken);
    Task<UserTokenCommandResponse> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> LoginStatusCodeAsync(LoginUserRequest request, CancellationToken cancellationToken);
    Task<UserCommandResponse> UpdateCurrentAsync(UpdateCurrentUserApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateCurrentStatusCodeAsync(UpdateCurrentUserApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateCurrentStatusCodeUnauthorizedAsync(UpdateCurrentUserApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeNonAdminAsync(DeleteUserApiRequest request, CancellationToken cancellationToken);
}
