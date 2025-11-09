using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

using Mapster;

namespace InstaConnect.Identity.Presentation.Features.Users.Mappings;

internal class UserPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllUsersApiRequest, GetAllUsersQueryRequest>()
            .ConstructUsing(src => new(
                new(src.Filter.FirstName, src.Filter.LastName, src.Filter.Name),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<GetAllUsersQueryResponse, GetAllUsersApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new UserApiResponse(
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

        config.NewConfig<GetUserByIdApiRequest, GetUserByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<GetUserByIdQueryResponse, GetUserByIdApiResponse>()
            .ConstructUsing(src => new(
                new(src.Data.Id,
                    src.Data.FirstName,
                    src.Data.LastName,
                    src.Data.Name,
                    src.Data.ProfileImage)));

        config.NewConfig<GetCurrentUserByIdApiRequest, GetUserByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<GetCurrentUserByIdQueryResponse, GetCurrentUserByIdApiResponse>()
            .ConstructUsing(src => new(
                new(src.Data.Id,
                    src.Data.FirstName,
                    src.Data.LastName,
                    src.Data.Name,
                    src.Data.ProfileImage)));

        config.NewConfig<GetUserDetailsByIdApiRequest, GetUserByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<GetUserDetailsByIdQueryResponse, GetUserDetailsByIdApiResponse>()
            .ConstructUsing(src => new(
                new(src.Data.Id,
                    src.Data.FirstName,
                    src.Data.LastName,
                    src.Data.Name,
                    src.Data.Email,
                    src.Data.ProfileImage)));

        config.NewConfig<GetCurrentUserByIdApiRequest, GetUserByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<GetCurrentUserDetailsByIdQueryResponse, GetCurrentUserDetailsByIdApiResponse>()
            .ConstructUsing(src => new(
                new(src.Data.Id,
                    src.Data.FirstName,
                    src.Data.LastName,
                    src.Data.Name,
                    src.Data.Email,
                    src.Data.ProfileImage)));

        config.NewConfig<AddUserApiRequest, AddUserCommandRequest>()
            .ConstructUsing(src => new(
                src.Form.Name,
                src.Form.Email,
                src.Form.Password,
                src.Form.ConfirmPassword,
                src.Form.FirstName,
                src.Form.LastName,
                src.Form.ProfileImage));

        config.NewConfig<AddUserCommandResponse, AddUserApiResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<UpdateCurrentUserApiRequest, UpdateCurrentUserCommandRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.Form.Email,
                src.Form.FirstName,
                src.Form.LastName,
                src.Form.Name,
                src.Form.ProfileImage));

        config.NewConfig<UpdateCurrentUserCommandResponse, UpdateCurrentUserApiResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeleteUserApiRequest, DeleteUserCommandRequest>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<DeleteCurrentUserApiRequest, DeleteUserCommandRequest>()
            .ConstructUsing(src => new(src.Id));
    }
}
