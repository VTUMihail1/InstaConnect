using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

using Mapster;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostCommentLikeQueryEntity, PostCommentLike>()
              .ConstructUsing(pcl => new(
                            pcl.Id,
                            pcl.CommentId,
                            pcl.CommentLikeId,
                            new User(
                                pcl.UserId,
                                pcl.UserFirstName,
                                pcl.UserLastName,
                                pcl.UserEmail,
                                pcl.UserName,
                                pcl.UserProfileImage,
                                pcl.UserCreatedAt,
                                pcl.UserUpdatedAt),
                            pcl.CreatedAt,
                            pcl.UpdatedAt));
    }
}
