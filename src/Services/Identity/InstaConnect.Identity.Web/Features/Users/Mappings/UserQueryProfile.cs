using AutoMapper;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllFilteredUsers;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUserDetailed;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserById;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserDetailedById;
using InstaConnect.Identity.Web.Features.Users.Models.Requests;
using InstaConnect.Identity.Web.Features.Users.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Identity.Web.Features.Users.Mappings;

internal class UserQueryProfile : Profile
{
    public UserQueryProfile()
    {
        CreateMap<GetAllUsersRequest, GetAllUsersQuery>();

        CreateMap<CurrentUserModel, GetCurrentUserDetailedQuery>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<GetUserDetailedByIdRequest, GetUserDetailedByIdQuery>();

        CreateMap<CurrentUserModel, GetCurrentUserQuery>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<GetUserByIdRequest, GetUserByIdQuery>();

        CreateMap<GetUserByNameRequest, GetUserByNameQuery>();

        CreateMap<UserQueryViewModel, UserQueryResponse>();

        CreateMap<UserDetailedQueryViewModel, UserDetailedQueryResponse>();

        CreateMap<UserPaginationQueryViewModel, UserPaginationQueryResponse>();
    }
}
