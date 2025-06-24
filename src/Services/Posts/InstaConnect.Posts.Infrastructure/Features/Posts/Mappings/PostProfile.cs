using AutoMapper;

using InstaConnect.Posts.Domain.Features.Posts.Models.Events;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Post, AddedPostEvent>();

        CreateMap<Post, UpdatedPostEvent>();

        CreateMap<Post, DeletedPostEvent>();
    }
}
