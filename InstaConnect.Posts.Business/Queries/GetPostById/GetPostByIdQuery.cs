using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.GetPostById
{
    public class GetPostByIdQuery : IQuery<PostViewDTO>
    {
        public string Id { get; set; }
    }
}
