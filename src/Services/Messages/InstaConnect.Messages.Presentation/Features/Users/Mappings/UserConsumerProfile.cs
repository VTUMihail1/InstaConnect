using AutoMapper;

using InstaConnect.Messages.Domain.Features.Users.Models.Entities;
using InstaConnect.Shared.Application.Contracts.Users;

namespace InstaConnect.Messages.Presentation.Features.Users.Mappings;
internal class UserConsumerProfile : Profile
{
    public UserConsumerProfile()
    {
        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();
    }
}
