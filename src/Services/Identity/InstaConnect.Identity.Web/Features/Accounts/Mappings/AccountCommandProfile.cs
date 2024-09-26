using AutoMapper;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ConfirmAccountEmail;
using InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteAccountById;
using InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.LoginAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResetAccountPassword;
using InstaConnect.Identity.Business.Features.Accounts.Commands.SendAccountPasswordReset;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Web.Features.Accounts.Models.Requests;
using InstaConnect.Identity.Web.Features.Accounts.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Identity.Web.Features.Accounts.Mappings;

internal class AccountCommandProfile : Profile
{
    public AccountCommandProfile()
    {
        CreateMap<ConfirmAccountEmailRequest, ConfirmAccountEmailCommand>();

        CreateMap<ResendAccountConfirmEmailRequest, ResendAccountEmailConfirmationCommand>();

        CreateMap<SendAccountPasswordResetRequest, SendAccountPasswordResetRequest>();

        CreateMap<CurrentUserModel, DeleteCurrentAccountCommand>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<SendAccountPasswordResetRequest ,SendAccountPasswordResetCommand>();

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
                src.Item2.EditCurrentAccountBindingModel.UserName,
                src.Item2.EditCurrentAccountBindingModel.ProfileImage));

        CreateMap<DeleteAccountByIdRequest, DeleteAccountByIdCommand>();

        CreateMap<AccountTokenCommandViewModel, AccountTokenCommandResponse>();

        CreateMap<AccountCommandViewModel, AccountCommandResponse>();
    }
}
