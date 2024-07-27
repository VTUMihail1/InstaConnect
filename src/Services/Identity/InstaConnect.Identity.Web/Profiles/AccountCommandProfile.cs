using AutoMapper;
using InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;
using InstaConnect.Identity.Business.Commands.Account.DeleteAccountById;
using InstaConnect.Identity.Business.Commands.Account.DeleteCurrentAccount;
using InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;
using InstaConnect.Identity.Business.Commands.Account.LoginAccount;
using InstaConnect.Identity.Business.Commands.Account.RegisterAccount;
using InstaConnect.Identity.Business.Commands.Account.ResendAccountEmailConfirmation;
using InstaConnect.Identity.Business.Commands.Account.ResetAccountPassword;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Web.Models.Requests.Account;
using InstaConnect.Identity.Web.Models.Response;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Identity.Web.Profiles;

internal class AccountCommandProfile : Profile
{
    public AccountCommandProfile()
    {
        CreateMap<ConfirmAccountEmailTokenRequest, ConfirmAccountEmailCommand>();

        CreateMap<ResendAccountConfirmEmailRequest, ResendAccountEmailConfirmationCommand>();

        CreateMap<SendAccountPasswordResetRequest, SendAccountPasswordResetRequest>();

        CreateMap<LoginAccountRequest, LoginAccountCommand>()
            .ConstructUsing(src => new(src.LoginAccountBindingModel.Email, src.LoginAccountBindingModel.Password));

        CreateMap<RegisterAccountRequest, RegisterAccountCommand>()
            .ConstructUsing(src => new(
                src.RegisterAccountBindingModel.UserName,
                src.RegisterAccountBindingModel.Email,
                src.RegisterAccountBindingModel.Password,
                src.RegisterAccountBindingModel.ConfirmPassword,
                src.RegisterAccountBindingModel.FirstName,
                src.RegisterAccountBindingModel.LastName,
                src.RegisterAccountBindingModel.ProfileImage));

        CreateMap<ResetAccountPasswordRequest, ResetAccountPasswordCommand>()
            .ConstructUsing(src => new(
                src.UserId,
                src.Token,
                src.ResetAccountPasswordBindingModel.Password,
                src.ResetAccountPasswordBindingModel.ConfirmPassword));

        CreateMap<(CurrentUserModel, EditCurrentAccountRequest), EditCurrentAccountCommand>()
            .ConstructUsing(src => new(
                src.Item1.Id,
                src.Item2.EditCurrentAccountBindingModel.FirstName,
                src.Item2.EditCurrentAccountBindingModel.LastName,
                src.Item2.EditCurrentAccountBindingModel.UserName));

        CreateMap<(CurrentUserModel, EditCurrentAccountProfileImageRequest), EditCurrentAccountProfileImageCommand>()
            .ConstructUsing(src => new(src.Item1.Id, src.Item2.EditCurrentAccountProfileImageBindingModel.ProfileImage));

        CreateMap<DeleteAccountByIdRequest, DeleteAccountByIdCommand>();

        CreateMap<AccountTokenCommandViewModel, AccountTokenCommandResponse>();

        CreateMap<AccountCommandViewModel, AccountCommandResponse>();
    }
}
