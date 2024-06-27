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
using InstaConnect.Identity.Business.Queries.User.GetUser;
using InstaConnect.Identity.Business.Queries.User.GetUserById;
using InstaConnect.Identity.Business.Queries.User.GetUserByName;
using InstaConnect.Identity.Business.Queries.User.GetUserDetailed;
using InstaConnect.Identity.Business.Queries.User.GetUserDetailedById;
using InstaConnect.Identity.Web.Models.Requests.Account;
using InstaConnect.Identity.Web.Models.Requests.User;
using InstaConnect.Identity.Web.Models.Response;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Identity.Web.Profiles;

public class UsersWebProfile : Profile
{
    public UsersWebProfile()
    {
        // Account 

        CreateMap<ConfirmAccountEmailTokenRequest, ConfirmAccountEmailCommand>();

        CreateMap<ResendAccountConfirmEmailRequest, ResendAccountEmailConfirmationCommand>();

        CreateMap<SendAccountPasswordResetRequest, SendAccountPasswordResetRequest>();

        CreateMap<LoginAccountRequest, LoginAccountCommand>();

        CreateMap<RegisterAccountRequest, RegisterAccountCommand>();

        CreateMap<ResetAccountPasswordRequest, ResetAccountPasswordCommand>();

        CreateMap<EditAccountRequest, EditAccountCommand>();

        CreateMap<DeleteAccountRequest, DeleteAccountCommand>();

        CreateMap<DeleteAccountByIdRequest, DeleteAccountByIdCommand>();

        CreateMap<AccountViewModel, AccountResponse>();

        // Users

        CreateMap<CollectionRequest, GetAllUsersQuery>();

        CreateMap<GetUserCollectionRequest, GetAllFilteredUsersQuery>();

        CreateMap<GetUserDetailedRequest, GetUserDetailedQuery>();

        CreateMap<GetUserDetailedByIdRequest, GetUserDetailedByIdQuery>();

        CreateMap<GetUserRequest, GetUserQuery>();

        CreateMap<GetUserByIdRequest, GetUserByIdQuery>();

        CreateMap<GetUserByNameRequest, GetUserByNameQuery>();

        CreateMap<UserViewModel, UserResponse>();

        CreateMap<UserDetailedViewModel, UserDetailedResponse>();
    }
}
