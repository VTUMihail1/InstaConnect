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

        CreateMap<CurrentUserDetails, GetCurrentUserDetailedQuery>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => nameof(GetCurrentUserDetailedQuery) + src.Id))
            .ForMember(dest => dest.Expiration, opt => opt.MapFrom(_ => DateTime.UtcNow.AddMinutes(15)));

        CreateMap<GetUserDetailedByIdRequest, GetUserDetailedByIdQuery>();

        CreateMap<CurrentUserDetails, GetCurrentUserQuery>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => nameof(GetCurrentUserDetailedQuery) + src.Id))
            .ForMember(dest => dest.Expiration, opt => opt.MapFrom(_ => DateTime.UtcNow.AddMinutes(15)));

        CreateMap<GetUserByIdRequest, GetUserByIdQuery>();

        CreateMap<GetUserByNameRequest, GetUserByNameQuery>();

        CreateMap<UserViewModel, UserResponse>();

        CreateMap<UserDetailedViewModel, UserDetailedResponse>();
    }
}
