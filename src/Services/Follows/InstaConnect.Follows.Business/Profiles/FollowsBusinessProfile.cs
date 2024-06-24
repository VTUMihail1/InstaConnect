using AutoMapper;
using InstaConnect.Follows.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Business.Models;
using InstaConnect.Follows.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Follows.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts;
using InstaConnect.Shared.Business.Models.Users;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Business.Profiles;

public class FollowsBusinessProfile : Profile
{
    public FollowsBusinessProfile()
    {
        // Follows

        CreateMap<UserDeletedEvent, FollowFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new FollowFilteredCollectionQuery
                 {
                     Expression = p => p.FollowerId == src.Id
                 });

        CreateMap<GetAllFilteredFollowsQuery, FollowFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new FollowFilteredCollectionQuery
                 {
                     Expression = p => (src.FollowerId == string.Empty || p.FollowerId == src.FollowerId) &&
                                       (src.FollowerName == string.Empty || p.FollowerName == src.FollowerName) &&
                                       (src.FollowingId == string.Empty || p.FollowingId == src.FollowingId) &&
                                       (src.FollowingName == string.Empty || p.FollowingName == src.FollowingName)
                 });

        CreateMap<GetAllFollowsQuery, CollectionQuery>();

        CreateMap<AddFollowCommand, GetUserByIdRequest>();

        CreateMap<CurrentUserDetails, Follow>()
            .ForMember(dest => dest.FollowerId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FollowerName, opt => opt.MapFrom(src => src.UserName));

        CreateMap<GetUserByIdResponse, Follow>()
            .ForMember(dest => dest.FollowingId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FollowerName, opt => opt.MapFrom(src => src.UserName));

        CreateMap<AddFollowCommand, Follow>();

        CreateMap<Follow, FollowViewModel>();
    }
}
