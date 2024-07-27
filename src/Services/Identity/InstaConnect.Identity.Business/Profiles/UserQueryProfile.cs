using AutoMapper;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Identity.Business.Queries.User.GetAllUsers;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Identity.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Identity.Business.Profiles;

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
