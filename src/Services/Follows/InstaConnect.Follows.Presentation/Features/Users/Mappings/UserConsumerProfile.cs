using AutoMapper;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Shared.Application.Contracts.Users;

namespace InstaConnect.Follows.Presentation.Features.Users.Mappings;
internal class UserConsumerProfile : Profile
{
    public UserConsumerProfile()
    {
        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();
    }
}
