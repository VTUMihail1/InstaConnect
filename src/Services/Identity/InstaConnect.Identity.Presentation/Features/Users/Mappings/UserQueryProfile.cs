using AutoMapper;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUserDetailed;
using InstaConnect.Identity.Application.Features.Users.Queries.GetUserById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Application.Features.Users.Queries.GetUserDetailedById;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Shared.Presentation.Models.Users;

namespace InstaConnect.Identity.Presentation.Features.Users.Mappings;

internal class UserQueryProfile : Profile
{
    public UserQueryProfile()
    {
        CreateMap<GetAllUsersRequest, GetAllUsersQuery>();

        CreateMap<CurrentUserModel, GetCurrentUserDetailedQuery>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<GetUserDetailedByIdRequest, GetUserDetailedByIdQuery>();

        CreateMap<CurrentUserModel, GetCurrentUserQuery>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<GetUserByIdRequest, GetUserByIdQuery>();

        CreateMap<GetUserByNameRequest, GetUserByNameQuery>();

        CreateMap<UserQueryViewModel, UserQueryResponse>();

        CreateMap<UserDetailedQueryViewModel, UserDetailedQueryResponse>();

        CreateMap<UserPaginationQueryViewModel, UserPaginationQueryResponse>();
    }
}
