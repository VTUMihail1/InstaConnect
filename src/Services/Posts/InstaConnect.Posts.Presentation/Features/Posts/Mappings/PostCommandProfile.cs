using AutoMapper;
using InstaConnect.Posts.Application.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Application.Features.Posts.Commands.DeletePost;
using InstaConnect.Posts.Application.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Shared.Presentation.Models.Users;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostCommandProfile : Profile
{
    public PostCommandProfile()
    {
        CreateMap<AddPostRequest, AddPostCommand>()
            .ConstructUsing(src => new(src.CurrentUserId, src.Body.Title, src.Body.Content));

        CreateMap<UpdatePostRequest, UpdatePostCommand>()
            .ConstructUsing(src => new(src.Id, src.CurrentUserId, src.Body.Title, src.Body.Content));

        CreateMap<DeletePostRequest, DeletePostCommand>()
            .ConstructUsing(src => new(src.CurrentUserId, src.Id));

        CreateMap<PostCommandViewModel, PostCommandResponse>();
    }
}
