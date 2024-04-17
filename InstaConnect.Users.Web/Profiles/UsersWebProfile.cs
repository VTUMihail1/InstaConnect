using AutoMapper;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Users.Business.Commands.AccountConfirmEmail;
using InstaConnect.Users.Business.Commands.AccountDelete;
using InstaConnect.Users.Business.Commands.AccountEdit;
using InstaConnect.Users.Business.Commands.AccountLogin;
using InstaConnect.Users.Business.Commands.AccountLogout;
using InstaConnect.Users.Business.Commands.AccountRegister;
using InstaConnect.Users.Business.Commands.AccountResendEmailConfirmation;
using InstaConnect.Users.Business.Commands.AccountResetPassword;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Business.Queries.GetAllFilteredUsers;
using InstaConnect.Users.Business.Queries.GetAllUsers;
using InstaConnect.Users.Business.Queries.GetPersonalUserById;
using InstaConnect.Users.Business.Queries.GetUserById;
using InstaConnect.Users.Business.Queries.GetUserByName;
using InstaConnect.Users.Data.Models.Filters;
using InstaConnect.Users.Web.Models.Requests.Account;
using InstaConnect.Users.Web.Models.Requests.Token;
using InstaConnect.Users.Web.Models.Requests.User;
using InstaConnect.Users.Web.Models.Response.Account;
using InstaConnect.Users.Web.Models.Response.User;

namespace InstaConnect.Users.Web.Profiles
{
    public class UsersWebProfile : Profile
    {
        public UsersWebProfile()
        {
            CreateMap<AccountConfirmEmailTokenRequestModel, AccountConfirmEmailCommand>();

            CreateMap<AccountResendConfirmEmailRequestModel, AccountResendEmailConfirmationCommand>();

            CreateMap<AccountSendPasswordResetRequestModel, AccountSendPasswordResetRequestModel>();

            CreateMap<AccountLoginRequestModel, AccountLoginCommand>();

            CreateMap<AccountRegisterRequestModel, AccountRegisterCommand>();

            CreateMap<AccountResetPasswordRequestModel, AccountResetPasswordCommand>();

            CreateMap<AccountEditRequestModel, AccountEditCommand>();

            CreateMap<TokenRequestModel, AccountLogoutCommand>();

            CreateMap<UserRequestModel, AccountEditCommand>();

            CreateMap<UserRequestModel, AccountDeleteCommand>();

            CreateMap<AccountDeleteRequestModel, AccountDeleteCommand>();

            CreateMap<AccountViewDTO, AccountResponseModel>();

            CreateMap<CollectionRequestModel, GetAllUsersQuery>();

            CreateMap<GetUserCollectionRequestModel, GetAllFilteredUsersQuery>();

            CreateMap<GetAllFilteredUsersQuery, UserFilteredCollection>()
                .ConstructUsing(src =>
                     new UserFilteredCollection
                     {
                         Expression = p => (src.UserName == string.Empty || p.UserName.Contains(src.UserName)) &&
                                           (src.FirstName == string.Empty || p.FirstName.Contains(src.UserName)) &&
                                           (src.LastName == string.Empty || p.LastName.Contains(src.UserName))
                     });


            CreateMap<UserRequestModel, GetDetailedUserByIdQuery>();

            CreateMap<GetUserDetailedByIdRequestModel, GetDetailedUserByIdQuery>();

            CreateMap<UserRequestModel, GetUserByIdQuery>();

            CreateMap<GetUserByIdRequestModel, GetUserByIdQuery>();

            CreateMap<GetUserByUserNameRequestModel, GetUserByNameQuery>();

            CreateMap<UserViewDTO, UserResponseModel>();

            CreateMap<UserDetailedViewDTO, UserDetailedResponseModel>();
        }
    }
}
