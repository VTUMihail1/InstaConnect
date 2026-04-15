using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserMapper
{
    extension(User user)
    {
        internal UserIdCommandResponse ToIdResponse(
)
        {
            return new(user.Id.Id);
        }

        internal UserQueryResponse ToFullResponse()
        {
            return new(user.Id.Id,
                       user.FirstName,
                       user.LastName,
                       user.Name.Value,
                       user.ProfileImage?.Url,
                       user.CreatedAtUtc,
                       user.UpdatedAtUtc);
        }

        internal UserDetailsQueryResponse ToFullDetailsResponse()
        {
            return new(user.Id.Id,
                       user.FirstName,
                       user.LastName,
                       user.Name.Value,
                       user.Email.Value,
                       user.ProfileImage?.Url,
                       user.CreatedAtUtc,
                       user.UpdatedAtUtc);
        }

        public AddUserCommandResponse ToResponse(
            AddUserApiRequest request)
        {
            return new(user.ToIdResponse());
        }

        public UpdateCurrentUserCommandResponse ToResponse(
            UpdateCurrentUserApiRequest request)
        {
            return new(user.ToIdResponse());
        }

        public GetUserByIdQueryResponse ToResponse(
            GetUserByIdApiRequest request)
        {
            return new(user.ToFullResponse());
        }

        public GetUserDetailsByIdQueryResponse ToResponse(
            GetUserDetailsByIdApiRequest request)
        {
            return new(user.ToFullDetailsResponse());
        }

        public GetCurrentUserByIdQueryResponse ToResponse(
            GetCurrentUserByIdApiRequest request)
        {
            return new(user.ToFullResponse());
        }

        public GetCurrentUserDetailsByIdQueryResponse ToResponse(
            GetCurrentUserDetailsByIdApiRequest request)
        {
            return new(user.ToFullDetailsResponse());
        }
    }

    extension(ICollection<User> users)
    {
        internal UserCollectionQueryResponse ToFullResponse<TRequest>(
        Func<User, TRequest, bool> filter,
        Func<User, TRequest, UserQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            var paginator = new Paginator();
            var totalCount = users.Count(user => filter(user, request));

            return new(users.Filter(user => filter(user, request), request, user => transform(user, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        public GetAllUsersQueryResponse ToResponse(
            GetAllUsersApiRequest request)
        {
            return new(users.ToFullResponse((user, request) => user.MatchesFilter(request),
                                                   (user, request) => user.ToFullResponse(),
                                                   request));
        }
    }
}
