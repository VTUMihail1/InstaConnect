using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;
using InstaConnect.Identity.Application.Features.Users.Models;
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
                                       new(
                                           src.FirstName,
                                           src.LastName,
                                           src.Name.Adapt<NamePayload>()),
                                       new(
                                           src.SortOrder,
                                           src.SortProperty),
                                       new(
                                           src.Page,
                                           src.PageSize)));

        config.NewConfig<GetAllUsersQueryResponse, GetAllUsersApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<UserApiResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetUserByIdApiRequest, GetUserByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<GetUserByIdQueryResponse, GetUserByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<UserApiResponse>()));

        config.NewConfig<GetCurrentUserByIdApiRequest, GetUserByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<GetCurrentUserByIdQueryResponse, GetCurrentUserByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<UserApiResponse>()));

        config.NewConfig<GetUserDetailsByIdApiRequest, GetUserByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<GetUserDetailsByIdQueryResponse, GetUserDetailsByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<UserDetailsApiResponse>()));

        config.NewConfig<GetCurrentUserByIdApiRequest, GetUserByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<GetCurrentUserDetailsByIdQueryResponse, GetCurrentUserDetailsByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<UserDetailsApiResponse>()));

        config.NewConfig<AddUserApiRequest, AddUserCommandRequest>()
            .ConstructUsing(src => new(
                src.Form.Name.Adapt<NamePayload>(),
                src.Form.Email.Adapt<EmailPayload>(),
                src.Form.Password,
                src.Form.ConfirmPassword,
                src.Form.FirstName,
                src.Form.LastName,
                src.Form.ProfileImage));

        config.NewConfig<AddUserCommandResponse, AddUserApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdApiPayload>()));

        config.NewConfig<UpdateCurrentUserApiRequest, UpdateCurrentUserCommandRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.Form.Email.Adapt<EmailPayload>(),
                src.Form.FirstName,
                src.Form.LastName,
                src.Form.Name.Adapt<NamePayload>(),
                src.Form.ProfileImage));

        config.NewConfig<UpdateCurrentUserCommandResponse, UpdateCurrentUserApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdApiPayload>()));

        config.NewConfig<DeleteUserApiRequest, DeleteUserCommandRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<DeleteCurrentUserApiRequest, DeleteUserCommandRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<UserIdApiPayload, UserIdPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<UserIdPayload, UserIdApiPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<UserQueryResponse, UserApiResponse>()
            .ConstructUsing(src => new(
                    src.Id.Adapt<UserIdApiPayload>(),
                    src.FirstName,
                    src.LastName,
                    src.Name.Adapt<NameApiPayload>(),
                    src.ProfileImage.Adapt<ImageApiPayload>(),
                    src.CreatedAtUtc,
                    src.UpdatedAtUtc));

        config.NewConfig<UserDetailsQueryResponse, UserDetailsApiResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdApiPayload>(),
                    src.FirstName,
                    src.LastName,
                    src.Name.Adapt<NameApiPayload>(),
                    src.Email.Adapt<EmailApiPayload>(),
                    src.ProfileImage.Adapt<ImageApiPayload>(),
                    src.CreatedAtUtc,
                    src.UpdatedAtUtc));
    }
}
