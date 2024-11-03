using AutoMapper;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;

namespace InstaConnect.Posts.Business.Features.Users.Mappings;
internal class UserConsumerProfile : Profile
{
    public UserConsumerProfile()
    {
        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();
    }
}
