using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;
using MediatR;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts
{
    public class GetAllFilteredPostCommentLikesQuery : CollectionDTO, IQuery<ICollection<PostCommentLikeViewDTO>>
    {
        public string UserId { get; set; }

        public string PostCommentId { get; set; }
    }
}
