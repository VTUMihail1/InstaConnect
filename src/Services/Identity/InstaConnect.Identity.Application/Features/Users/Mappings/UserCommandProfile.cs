using AutoMapper;

using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;
using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Update;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Domain.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Application.Models;

namespace InstaConnect.Identity.Application.Features.Users.Mappings;

internal class UserCommandProfile : Profile
{
    public UserCommandProfile()
    {
        CreateMap<(PasswordHashResultModel, AddUserCommand), User>()
            .ConstructUsing(src => new(
                src.Item2.FirstName,
                src.Item2.LastName,
                src.Item2.Email,
                src.Item2.UserName,
                src.Item1.PasswordHash,
                null!));

        CreateMap<(ICollection<UserClaim>, User), CreateAccessTokenModel>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item2.Email, src.Item2.FirstName, src.Item2.LastName, src.Item2.UserName, src.Item1));

        CreateMap<UpdateUserCommand, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<AccessTokenResult, UserTokenCommandViewModel>();

        CreateMap<User, UserCreatedEvent>();

        CreateMap<User, CreateEmailConfirmationTokenModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.Email));

        CreateMap<User, UserUpdatedEvent>();

        CreateMap<User, UserDeletedEvent>();

        CreateMap<User, UserClaimCollectionWriteQuery>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<ImageResult, User>()
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ImageUri));

        CreateMap<UpdateUserCommand, ImageUploadModel>()
            .ConstructUsing(src => new(src.ProfileImageFile!));

        CreateMap<AddUserCommand, ImageUploadModel>()
            .ConstructUsing(src => new(src.ProfileImage!));

        CreateMap<ImageResult, User>()
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ImageUri));

        CreateMap<User, UserCommandViewModel>();
    }
}
