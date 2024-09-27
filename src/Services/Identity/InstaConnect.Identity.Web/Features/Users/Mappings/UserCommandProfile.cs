using AutoMapper;
using InstaConnect.Identity.Business.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Business.Features.Users.Commands.DeleteCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Commands.DeleteUserById;
using InstaConnect.Identity.Business.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Business.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Business.Features.Users.Commands.ResendUserEmailConfirmation;
using InstaConnect.Identity.Business.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Business.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Web.Features.Users.Models.Requests;
using InstaConnect.Identity.Web.Features.Users.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Identity.Web.Features.Users.Mappings;

internal class UserCommandProfile : Profile
{
    public UserCommandProfile()
    {
        CreateMap<ConfirmUserEmailRequest, ConfirmUserEmailCommand>();

        CreateMap<ResendUserConfirmEmailRequest, ResendUserEmailConfirmationCommand>();

        CreateMap<SendUserPasswordResetRequest, SendUserPasswordResetRequest>();

        CreateMap<CurrentUserModel, DeleteCurrentUserCommand>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<SendUserPasswordResetRequest, SendUserPasswordResetCommand>();

        CreateMap<LoginUserRequest, LoginUserCommand>()
            .ConstructUsing(src => new(src.LoginUserBindingModel.Email, src.LoginUserBindingModel.Password));

        CreateMap<RegisterUserRequest, RegisterUserCommand>()
            .ConstructUsing(src => new(
                src.RegisterUserBindingModel.UserName,
                src.RegisterUserBindingModel.Email,
                src.RegisterUserBindingModel.Password,
                src.RegisterUserBindingModel.ConfirmPassword,
                src.RegisterUserBindingModel.FirstName,
                src.RegisterUserBindingModel.LastName,
                src.RegisterUserBindingModel.ProfileImage));

        CreateMap<ResetUserPasswordRequest, ResetUserPasswordCommand>()
            .ConstructUsing(src => new(
                src.UserId,
                src.Token,
                src.ResetUserPasswordBindingModel.Password,
                src.ResetUserPasswordBindingModel.ConfirmPassword));

        CreateMap<(CurrentUserModel, EditCurrentUserRequest), EditCurrentUserCommand>()
            .ConstructUsing(src => new(
                src.Item1.Id,
                src.Item2.EditCurrentUserBindingModel.FirstName,
                src.Item2.EditCurrentUserBindingModel.LastName,
                src.Item2.EditCurrentUserBindingModel.UserName,
                src.Item2.EditCurrentUserBindingModel.ProfileImage));

        CreateMap<DeleteUserByIdRequest, DeleteUserByIdCommand>();

        CreateMap<UserTokenCommandViewModel, UserTokenCommandResponse>();

        CreateMap<UserCommandViewModel, UserCommandResponse>();
    }
}
