using AutoMapper;

using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.Login;
using InstaConnect.Identity.Application.Features.Users.Commands.Update;

namespace InstaConnect.Identity.Presentation.Features.Users.Mappings;

internal class UserCommandProfile : Profile
{
    public UserCommandProfile()
    {
        CreateMap<LoginUserRequest, LoginUserCommand>()
            .ConstructUsing(src => new(src.Body.Email, src.Body.Password));

        CreateMap<AddUserRequest, AddUserCommand>()
            .ConstructUsing(src => new(
                src.Form.UserName,
                src.Form.Email,
                src.Form.Password,
                src.Form.ConfirmPassword,
                src.Form.FirstName,
                src.Form.LastName,
                src.Form.ProfileImage));

        CreateMap<UpdateCurrentUserRequest, UpdateUserCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.Form.FirstName,
                src.Form.LastName,
                src.Form.UserName,
                src.Form.ProfileImage));

        CreateMap<DeleteUserRequest, DeleteUserCommand>();

        CreateMap<DeleteCurrentUserRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<UserTokenCommandViewModel, UserTokenCommandResponse>();

        CreateMap<UserCommandViewModel, UserCommandResponse>();
    }
}
