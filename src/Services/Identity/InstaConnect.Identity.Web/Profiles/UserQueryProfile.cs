using AutoMapper;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Identity.Business.Queries.User.GetAllUsers;
using InstaConnect.Identity.Business.Queries.User.GetCurrentUser;
using InstaConnect.Identity.Business.Queries.User.GetCurrentUserDetailed;
using InstaConnect.Identity.Business.Queries.User.GetUserById;
using InstaConnect.Identity.Business.Queries.User.GetUserByName;
using InstaConnect.Identity.Business.Queries.User.GetUserDetailedById;
using InstaConnect.Identity.Web.Models.Requests.User;
using InstaConnect.Identity.Web.Models.Response;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Identity.Web.Profiles;

internal class UserQueryProfile : Profile
{
    public UserQueryProfile()
    {
        CreateMap<GetAllUsersRequest, GetAllUsersQuery>();

        CreateMap<GetAllFilteredUsersRequest, GetAllFilteredUsersQuery>();

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
