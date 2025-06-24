using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostCommandProfile : Profile
{
    public PostCommandProfile()
    {
        CreateMap<AddPostApiRequest, AddPostCommand>()
            .ConstructUsing(src => new(src.CurrentUserId, src.Body.Title, src.Body.Content));

        CreateMap<UpdatePostApiRequest, UpdatePostCommand>()
            .ConstructUsing(src => new(src.Id, src.CurrentUserId, src.Body.Title, src.Body.Content));

        CreateMap<DeletePostApiRequest, DeletePostCommand>()
            .ConstructUsing(src => new(src.Id, src.CurrentUserId));

        CreateMap<AddPostCommandResponse, AddPostApiResponse>();

        CreateMap<UpdatePostCommandResponse, UpdatePostApiResponse>();
    }
}
