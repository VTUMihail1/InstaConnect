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
using InstaConnect.Users.Web.Models.Response.Account;
using InstaConnect.Users.Web.Models.Response.User;

namespace InstaConnect.Users.Web.Profiles;

public class UsersWebProfile : Profile
{
    public UsersWebProfile()
    {
        // Account 

        CreateMap<ConfirmAccountEmailTokenRequestModel, ConfirmAccountEmailCommand>();

        CreateMap<ResendAccountConfirmEmailRequestModel, ResendAccountEmailConfirmationCommand>();

        CreateMap<SendAccountPasswordResetRequestModel, SendAccountPasswordResetRequestModel>();

        CreateMap<LoginAccountRequestModel, LoginAccountCommand>();

        CreateMap<RegisterAccountRequestModel, RegisterAccountCommand>();

        CreateMap<ResetAccountPasswordRequestModel, ResetAccountPasswordCommand>();

        CreateMap<EditAccountRequestModel, EditAccountCommand>();

        CreateMap<DeleteAccountRequestModel, DeleteAccountCommand>();

        CreateMap<DeleteAccountByIdRequestModel, DeleteAccountByIdCommand>();

        CreateMap<AccountViewDTO, AccountResponseModel>();

        // Users

        CreateMap<CollectionRequestModel, GetAllUsersQuery>();

        CreateMap<GetUserCollectionRequestModel, GetAllFilteredUsersQuery>();

        CreateMap<GetUserDetailedRequestModel, GetUserDetailedQuery>();

        CreateMap<GetUserDetailedByIdRequestModel, GetUserDetailedByIdQuery>();

        CreateMap<GetUserRequestModel, GetUserQuery>();

        CreateMap<GetUserByIdRequestModel, GetUserByIdQuery>();

        CreateMap<GetUserByNameRequestModel, GetUserByNameQuery>();

        CreateMap<UserViewDTO, UserResponseModel>();

        CreateMap<UserDetailedViewDTO, UserDetailedResponseModel>();
    }
}
