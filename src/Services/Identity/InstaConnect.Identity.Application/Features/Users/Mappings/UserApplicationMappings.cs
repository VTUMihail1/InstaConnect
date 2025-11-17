using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Identity.Application.Features.Users.Mappings;

public class UserApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllUsersQueryRequest, GetAllUsersQuery>()
            .ConstructUsing(src => new(
                src.Filter.Adapt<UserFilterQuery>(),
                src.Sorting.Adapt<UserSortingQuery>(),
                src.Pagination.Adapt<UserPaginationQuery>()));

        config.NewConfig<UserCollection, GetAllUsersQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<UserQueryResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetUserByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<UserId>()));

        config.NewConfig<User, GetUserByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.Id.Adapt<UserIdPayload>(),
                    src.FirstName,
                    src.LastName,
                    src.Name.Adapt<NamePayload>(),
                    src.ProfileImage.Adapt<ImagePayload>(),
                    src.CreatedAtUtc,
                    src.UpdatedAtUtc)));

        config.NewConfig<GetCurrentUserByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<UserId>()));

        config.NewConfig<User, GetCurrentUserByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<UserQueryResponse>()));

        config.NewConfig<GetUserDetailsByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<UserId>()));

        config.NewConfig<User, GetUserDetailsByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<UserDetailsQueryResponse>()));

        config.NewConfig<GetCurrentUserDetailsByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<UserId>()));

        config.NewConfig<User, GetCurrentUserDetailsByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<UserDetailsQueryResponse>())));

        config.NewConfig<AddUserCommandRequest, AddUserCommand>()
            .ConstructUsing(src => new(
                src.Name.Adapt<Name>(),
                src.Email.Adapt<Email>(),
                src.Password,
                src.ConfirmPassword,
                src.FirstName,
                src.LastName,
                src.ProfileImage));

        config.NewConfig<User, AddUserCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<UpdateCurrentUserCommandRequest, UpdateUserCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserId>(),
                src.Email.Adapt<Email>(),
                src.FirstName,
                src.LastName,
                src.Name.Adapt<Name>(),
                src.ProfileImage));

        config.NewConfig<User, UpdateCurrentUserCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<DeleteUserCommandRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<UserId>()));

        config.NewConfig<DeleteCurrentUserCommandRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<UserId>()));

        config.NewConfig<UserId, UserIdPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<UserIdPayload, UserId>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<User, UserQueryResponse>()
            .ConstructUsing(src => new(
                    src.Id.Adapt<UserIdPayload>(),
                    src.FirstName,
                    src.LastName,
                    src.Name.Adapt<NamePayload>(),
                    src.ProfileImage.Adapt<ImagePayload>(),
                    src.CreatedAtUtc,
                    src.UpdatedAtUtc));

        config.NewConfig<User, UserDetailsQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                    src.FirstName,
                    src.LastName,
                    src.Name.Adapt<NamePayload>(),
                    src.Email.Adapt<EmailPayload>(),
                    src.ProfileImage.Adapt<ImagePayload>(),
                    src.CreatedAtUtc,
                    src.UpdatedAtUtc));

        config.NewConfig<UserFilterQueryRequest, UserFilterQuery>()
            .ConstructUsing(src => new(
                src.FirstName,
                src.LastName,
                src.Name.Adapt<Name>()));

        config.NewConfig<UserSortingQueryRequest, UserSortingQuery>()
            .ConstructUsing(src => new(
                src.Order,
                src.Property));

        config.NewConfig<UserPaginationQueryRequest, UserPaginationQuery>()
            .ConstructUsing(src => new(
                src.Page,
                src.PageSize));
    }
}
