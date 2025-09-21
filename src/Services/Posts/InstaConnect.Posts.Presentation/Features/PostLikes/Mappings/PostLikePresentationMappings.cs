using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.Features.PostLikes.Models;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

using Mapster;

namespace InstaConnect.PostLikes.Presentation.Features.PostLikes.Mappings;

internal class PostLikePresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostLikesApiRequest, GetAllPostLikesQueryRequest>()
            .ConstructUsing(src => new(
                new(src.Filter.Id, src.Filter.UserName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<GetAllPostLikesQueryResponse, GetAllPostLikesApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new PostLikeApiResponse(
                                      p.Id,
                                      new(
                                          p.User.Id,
                                          p.User.Name,
                                          p.User.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetPostLikeByIdApiRequest, GetPostLikeByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id, src.UserId));

        config.NewConfig<GetPostLikeByIdQueryResponse, GetPostLikeByIdApiResponse>()
            .ConstructUsing(src => new(
                new(src.Data.Id,
                    new(
                        src.Data.User.Id,
                        src.Data.User.Name,
                        src.Data.User.ProfileImage))));

        config.NewConfig<AddPostLikeApiRequest, AddPostLikeCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.UserId));

        config.NewConfig<AddPostLikeCommandResponse, AddPostLikeApiResponse>()
            .ConstructUsing(src => new(src.Id, src.UserId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeletePostLikeApiRequest, DeletePostLikeCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.UserId));
    }
}
