using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.DTOs.PostLike;

namespace InstaConnect.Business.Models.DTOs.Post
{
    public class PostResultDTO
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<PostLikeResultDTO> PostLikes { get; set; }

        public ICollection<PostCommentResultDTO> PostComments { get; set; }
    }
}
