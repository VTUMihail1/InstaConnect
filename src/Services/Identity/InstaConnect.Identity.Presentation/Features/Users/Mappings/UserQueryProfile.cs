using AutoMapper;

using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetByName;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrent;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailed;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailedById;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Presentation.Features.Users.Mappings;

internal class UserQueryProfile : Profile
{
    public UserQueryProfile()
    {
        CreateMap<GetAllUsersRequest, GetAllUsersQuery>();

        CreateMap<GetCurrentDetailedUserRequest, GetCurrentDetailedUserQuery>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<GetDetailedUserByIdRequest, GetDetailedUserByIdQuery>();

        CreateMap<GetCurrentUserRequest, GetCurrentUserQuery>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<GetUserByIdRequest, GetUserByIdQuery>();

        CreateMap<GetUserByNameRequest, GetUserByNameQuery>();

        CreateMap<UserQueryViewModel, UserQueryResponse>();

        CreateMap<UserDetailedQueryViewModel, UserDetailedQueryResponse>();

        CreateMap<UserPaginationQueryViewModel, UserPaginationQueryResponse>();
    }
}
