﻿using AutoMapper;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;
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
