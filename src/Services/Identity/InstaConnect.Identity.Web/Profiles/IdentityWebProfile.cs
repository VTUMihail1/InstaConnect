using AutoMapper;
using InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;
using InstaConnect.Identity.Business.Commands.Account.DeleteAccount;
using InstaConnect.Identity.Business.Commands.Account.DeleteAccountById;
using InstaConnect.Identity.Business.Commands.Account.EditAccount;
using InstaConnect.Identity.Business.Commands.Account.LoginAccount;
using InstaConnect.Identity.Business.Commands.Account.RegisterAccount;
using InstaConnect.Identity.Business.Commands.Account.ResendAccountEmailConfirmation;
using InstaConnect.Identity.Business.Commands.Account.ResetAccountPassword;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Identity.Business.Queries.User.GetAllUsers;
using InstaConnect.Identity.Business.Queries.User.GetCurrentUser;
using InstaConnect.Identity.Business.Queries.User.GetCurrentUserDetailed;
using InstaConnect.Identity.Business.Queries.User.GetUserById;
using InstaConnect.Identity.Business.Queries.User.GetUserByName;
using InstaConnect.Identity.Business.Queries.User.GetUserDetailedById;
using InstaConnect.Identity.Web.Models.Requests.Account;
using InstaConnect.Identity.Web.Models.Requests.User;
using InstaConnect.Identity.Web.Models.Response;
using InstaConnect.Shared.Business.Models.Users;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Identity.Web.Profiles;

public class IdentityWebProfile : Profile
{
    public IdentityWebProfile()
    {
        // Accounts

        CreateMap<ConfirmAccountEmailTokenRequest, ConfirmAccountEmailCommand>();

        CreateMap<ResendAccountConfirmEmailRequest, ResendAccountEmailConfirmationCommand>();

        CreateMap<SendAccountPasswordResetRequest, SendAccountPasswordResetRequest>();

        CreateMap<LoginAccountRequest, LoginAccountCommand>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.LoginAccountBindingModel.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.LoginAccountBindingModel.Password));

        CreateMap<RegisterAccountRequest, RegisterAccountCommand>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.RegisterAccountBindingModel.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.RegisterAccountBindingModel.UserName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.RegisterAccountBindingModel.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.RegisterAccountBindingModel.LastName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.RegisterAccountBindingModel.Password))
            .ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.RegisterAccountBindingModel.ConfirmPassword));

        CreateMap<ResetAccountPasswordRequest, ResetAccountPasswordCommand>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.ResetAccountPasswordBindingModel.Password))
            .ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.ResetAccountPasswordBindingModel.ConfirmPassword));

        CreateMap<EditCurrentAccountRequest, EditCurrentAccountCommand>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.EditAccountBindingModel.UserName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.EditAccountBindingModel.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.EditAccountBindingModel.LastName));

        CreateMap<CurrentUserModel, EditCurrentAccountCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<CurrentUserModel, DeleteCurrentAccountCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeleteAccountByIdRequest, DeleteAccountByIdCommand>();

        CreateMap<AccountViewModel, AccountResponse>();

        // Users

        CreateMap<GetAllUsersRequest, GetAllUsersQuery>();

        CreateMap<GetAllFilteredUsersRequest, GetAllFilteredUsersQuery>();

        CreateMap<CurrentUserModel, GetCurrentUserDetailedQuery>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<GetUserDetailedByIdRequest, GetUserDetailedByIdQuery>();

        CreateMap<CurrentUserModel, GetCurrentUserQuery>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<GetUserByIdRequest, GetUserByIdQuery>();

        CreateMap<GetUserByNameRequest, GetUserByNameQuery>();

        CreateMap<UserViewModel, UserResponse>();

        CreateMap<UserDetailedViewModel, UserDetailedResponse>();
    }
}
