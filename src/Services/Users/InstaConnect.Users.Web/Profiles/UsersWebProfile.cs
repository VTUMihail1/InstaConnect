using AutoMapper;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Users.Business.Commands.Account.ConfirmAccountEmail;
using InstaConnect.Users.Business.Commands.Account.DeleteAccount;
using InstaConnect.Users.Business.Commands.Account.DeleteAccountById;
using InstaConnect.Users.Business.Commands.Account.EditAccount;
using InstaConnect.Users.Business.Commands.Account.LoginAccount;
using InstaConnect.Users.Business.Commands.Account.RegisterAccount;
using InstaConnect.Users.Business.Commands.Account.ResendAccountEmailConfirmation;
using InstaConnect.Users.Business.Commands.Account.ResetAccountPassword;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Users.Business.Queries.User.GetAllUsers;
using InstaConnect.Users.Business.Queries.User.GetUser;
using InstaConnect.Users.Business.Queries.User.GetUserById;
using InstaConnect.Users.Business.Queries.User.GetUserByName;
using InstaConnect.Users.Business.Queries.User.GetUserDetailed;
using InstaConnect.Users.Business.Queries.User.GetUserDetailedById;
using InstaConnect.Users.Web.Models.Requests.Account;
using InstaConnect.Users.Web.Models.Requests.User;
using InstaConnect.Users.Web.Models.Response;

namespace InstaConnect.Users.Web.Profiles;

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
