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
                new(src.Filter.FirstName, src.Filter.LastName, src.Filter.Name),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<UserCollection, GetAllUsersQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new UserQueryResponse(
                                      p.Id,
                                      p.FirstName,
                                      p.LastName,
                                      p.Name,
                                      p.ProfileImage))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetUserByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<User, GetUserByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.Id,
                    src.FirstName,
                    src.LastName,
                    src.Name,
                    src.ProfileImage)));

        config.NewConfig<GetCurrentUserByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<User, GetCurrentUserByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.Id,
                    src.FirstName,
                    src.LastName,
                    src.Name,
                    src.ProfileImage)));

        config.NewConfig<GetUserDetailsByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<User, GetUserDetailsByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.Id,
                    src.FirstName,
                    src.LastName,
                    src.Name,
                    src.Email,
                    src.ProfileImage)));

        config.NewConfig<GetCurrentUserDetailsByIdQueryRequest, GetUserByIdQuery>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<User, GetCurrentUserDetailsByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.Id,
                    src.FirstName,
                    src.LastName,
                    src.Name,
                    src.Email,
                    src.ProfileImage)));

        config.NewConfig<AddUserCommandRequest, AddUserCommand>()
            .ConstructUsing(src => new(
                src.Name,
                src.Email,
                src.Password,
                src.ConfirmPassword,
                src.FirstName,
                src.LastName,
                src.ProfileImage));

        config.NewConfig<User, AddUserCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<UpdateCurrentUserCommandRequest, UpdateUserCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.Email,
                src.FirstName,
                src.LastName,
                src.Name,
                src.ProfileImage));

        config.NewConfig<User, UpdateCurrentUserCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeleteUserCommandRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<DeleteCurrentUserCommandRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(src.Id));
    }
}
