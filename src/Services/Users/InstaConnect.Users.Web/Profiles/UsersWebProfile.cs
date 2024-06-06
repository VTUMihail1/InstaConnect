using AutoMapper;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Users.Business.Commands.Account.ConfirmAccountEmail;
using InstaConnect.Users.Business.Commands.Account.DeleteAccount;
using InstaConnect.Users.Business.Commands.Account.EditAccount;
using InstaConnect.Users.Business.Commands.Account.LoginAccount;
using InstaConnect.Users.Business.Commands.Account.LogoutAccount;
using InstaConnect.Users.Business.Commands.Account.RegisterAccount;
using InstaConnect.Users.Business.Commands.Account.ResendAccountEmailConfirmation;
using InstaConnect.Users.Business.Commands.Account.ResetAccountPassword;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Users.Business.Queries.User.GetAllUsers;
using InstaConnect.Users.Business.Queries.User.GetDetailedUserById;
using InstaConnect.Users.Business.Queries.User.GetUserById;
using InstaConnect.Users.Business.Queries.User.GetUserByName;
using InstaConnect.Users.Web.Models.Requests.Account;
using InstaConnect.Users.Web.Models.Requests.Token;
using InstaConnect.Users.Web.Models.Requests.User;
using InstaConnect.Users.Web.Models.Response.Account;
using InstaConnect.Users.Web.Models.Response.User;

namespace InstaConnect.Users.Web.Profiles;

public class UsersWebProfile : Profile
{
    public UsersWebProfile()
    {
        CreateMap<ConfirmAccountEmailTokenRequestModel, ConfirmAccountEmailCommand>();

        CreateMap<ResendAccountConfirmEmailRequestModel, ResendAccountEmailConfirmationCommand>();

        CreateMap<SendAccountPasswordResetRequestModel, SendAccountPasswordResetRequestModel>();

        CreateMap<LoginAccountRequestModel, LoginAccountCommand>();

        CreateMap<RegisterAccountRequestModel, RegisterAccountCommand>();

        CreateMap<ResetAccountPasswordRequestModel, ResetAccountPasswordCommand>();

        CreateMap<EditAccountRequestModel, EditAccountCommand>();

        CreateMap<TokenRequestModel, LogoutAccountCommand>();

        CreateMap<UserRequestModel, EditAccountCommand>();

        CreateMap<UserRequestModel, DeleteAccountCommand>();

        CreateMap<DeleteAccountRequestModel, DeleteAccountCommand>();

        CreateMap<AccountViewDTO, AccountResponseModel>();

        CreateMap<CollectionRequestModel, GetAllUsersQuery>();

        CreateMap<GetUserCollectionRequestModel, GetAllFilteredUsersQuery>();

        CreateMap<UserRequestModel, GetDetailedUserByIdQuery>();

        CreateMap<GetUserDetailedByIdRequestModel, GetDetailedUserByIdQuery>();

        CreateMap<UserRequestModel, GetUserByIdQuery>();

        CreateMap<GetUserByIdRequestModel, GetUserByIdQuery>();

        CreateMap<GetUserByUserNameRequestModel, GetUserByNameQuery>();

        CreateMap<UserViewDTO, UserResponseModel>();

        CreateMap<UserDetailedViewDTO, UserDetailedResponseModel>();
    }
}
