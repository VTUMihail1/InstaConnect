using AutoMapper;
using InstaConnect.Messages.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;

namespace InstaConnect.Messages.Business.Features.Users.Mappings;
internal class UserConsumerProfile : Profile
{
    public UserConsumerProfile()
    {
        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();
    }
}
