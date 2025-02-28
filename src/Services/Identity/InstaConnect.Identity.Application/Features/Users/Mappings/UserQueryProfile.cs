using AutoMapper;

using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Domain.Features.Users.Models.Filters;

namespace InstaConnect.Identity.Application.Features.Users.Mappings;

internal class UserQueryProfile : Profile
{
    public UserQueryProfile()
    {
        CreateMap<User, UserQueryViewModel>();

        CreateMap<User, UserDetailedQueryViewModel>();

        CreateMap<GetAllUsersQuery, UserCollectionReadQuery>();

        CreateMap<PaginationList<User>, UserPaginationQueryViewModel>();
    }
}
