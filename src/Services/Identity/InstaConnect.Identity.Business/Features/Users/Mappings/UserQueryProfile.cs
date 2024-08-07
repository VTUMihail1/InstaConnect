using AutoMapper;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllFilteredUsers;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Models.Filters;

namespace InstaConnect.Identity.Business.Features.Users.Mappings;

internal class UserQueryProfile : Profile
{
    public UserQueryProfile()
    {
        CreateMap<User, UserQueryViewModel>();

        CreateMap<User, UserDetailedQueryViewModel>();

        CreateMap<GetAllUsersQuery, UserFilteredCollectionReadQuery>();
    }
}
