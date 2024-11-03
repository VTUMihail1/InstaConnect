using AutoMapper;
using InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Business.Features.Posts.Commands.DeletePost;
using InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Web.Features.Posts.Models.Requests;
using InstaConnect.Posts.Web.Features.Posts.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Posts.Web.Features.Posts.Mappings;

internal class PostCommandProfile : Profile
{
    public PostCommandProfile()
    {
        CreateMap<(CurrentUserModel, AddPostRequest), AddPostCommand>()
            .ConstructUsing(src => new(src.Item1.Id, src.Item2.AddPostBindingModel.Title, src.Item2.AddPostBindingModel.Content));

        CreateMap<(CurrentUserModel, UpdatePostRequest), UpdatePostCommand>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item1.Id, src.Item2.UpdatePostBindingModel.Title, src.Item2.UpdatePostBindingModel.Content));

        CreateMap<(CurrentUserModel, DeletePostRequest), DeletePostCommand>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item1.Id));

        CreateMap<PostCommandViewModel, PostCommandResponse>();
    }
}
