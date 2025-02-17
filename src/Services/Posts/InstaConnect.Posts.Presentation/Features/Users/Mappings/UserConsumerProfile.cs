using AutoMapper;

using InstaConnect.Shared.Application.Contracts.Users;

namespace InstaConnect.Posts.Presentation.Features.Users.Mappings;
internal class UserConsumerProfile : Profile
{
    public UserConsumerProfile()
    {
        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();
    }
}
