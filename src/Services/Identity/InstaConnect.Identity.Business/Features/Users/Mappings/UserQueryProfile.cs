using AutoMapper;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllFilteredUsers;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Models.Filters;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Identity.Business.Features.Users.Mappings;

internal class UserQueryProfile : Profile
{
    public UserQueryProfile()
    {
        CreateMap<User, UserQueryViewModel>();

        CreateMap<User, UserDetailedQueryViewModel>();

        CreateMap<GetAllFilteredUsersQuery, UserFilteredCollectionReadQuery>();

        CreateMap<GetAllUsersQuery, CollectionReadQuery>();
    }
}
