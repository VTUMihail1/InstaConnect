using AutoMapper;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Commands.Posts.DeletePost;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Web.Models.Responses.Posts;
using InstaConnect.Posts.Write.Web.Models.Requests.Post;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Posts.Web.Profiles.Posts;

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
