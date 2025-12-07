using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

using Mapster;

namespace InstaConnect.Identity.Application.Features.Users.Mappings;

public class UserApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllUsersQueryRequest, GetAllUsersQuery>()
            .ConstructUsing(src => new(
                                       new(src.FirstName,
                                           src.LastName,
                                           new(src.Name)),
                                       new(
                                           src.SortOrder,
                                           src.SortProperty),
                                       new(
                                           src.Page,
                                           src.PageSize)));

        config.NewConfig<UserCollection, GetAllUsersQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<UserCollectionQueryResponse>(config)));

        config.NewConfig<GetUserByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(
                                       new(src.Id)));

        config.NewConfig<User, GetUserByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<UserQueryResponse>(config)));

        config.NewConfig<GetCurrentUserByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(
                                       new(src.Id)));

        config.NewConfig<User, GetCurrentUserByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<UserQueryResponse>(config)));

        config.NewConfig<GetUserDetailsByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(
                                       new(src.Id)));

        config.NewConfig<User, GetUserDetailsByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<UserDetailsQueryResponse>(config)));

        config.NewConfig<GetCurrentUserDetailsByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(
                                       new(src.Id)));

        config.NewConfig<User, GetCurrentUserDetailsByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<UserDetailsQueryResponse>(config)));

        config.NewConfig<AddUserCommandRequest, AddUserCommand>()
            .ConstructUsing(src => new(
                new(src.Name),
                new(src.Email),
                src.Password,
                src.ConfirmPassword,
                src.FirstName,
                src.LastName,
                src.ProfileImage));

        config.NewConfig<User, AddUserCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdCommandResponse>(config)));

        config.NewConfig<UpdateCurrentUserCommandRequest, UpdateUserCommand>()
            .ConstructUsing(src => new(
                new(src.Id),
                new(src.Email),
                src.FirstName,
                src.LastName,
                new(src.Name),
                src.ProfileImage));

        config.NewConfig<User, UpdateCurrentUserCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdCommandResponse>(config)));

        config.NewConfig<DeleteUserCommandRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(
                                       new(src.Id)));

        config.NewConfig<DeleteCurrentUserCommandRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(
                                       new(src.Id)));

        config.NewConfig<UserId, UserIdCommandResponse>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<User, UserQueryResponse>()
            .ConstructUsing(src => new(
                    src.Id.Id,
                    src.FirstName,
                    src.LastName,
                    src.Name.Value,
                    src.ProfileImage.IsNull() ? null : src.ProfileImage!.Url,
                    src.CreatedAtUtc,
                    src.UpdatedAtUtc));

        config.NewConfig<User, UserDetailsQueryResponse>()
            .ConstructUsing(src => new(
                  src.Id.Id,
                  src.FirstName,
                  src.LastName,
                  src.Name.Value,
                  src.Email.Value,
                  src.ProfileImage.IsNull() ? null : src.ProfileImage!.Url,
                  src.CreatedAtUtc,
                  src.UpdatedAtUtc));

        config.NewConfig<UserCollection, UserCollectionQueryResponse>()
            .ConstructUsing(src => new(
                  src.Entities.Adapt<ICollection<UserQueryResponse>>(config),
                  src.Page,
                  src.PageSize,
                  src.TotalCount,
                  src.HasNextPage,
                  src.HasPreviousPage));
    }
}
