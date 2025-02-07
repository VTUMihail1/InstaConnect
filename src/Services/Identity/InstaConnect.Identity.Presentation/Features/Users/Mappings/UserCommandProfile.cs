using AutoMapper;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteUserById;
using InstaConnect.Identity.Application.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Application.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Application.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Shared.Presentation.Models.Users;

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
