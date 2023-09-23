using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.DTOs.PostLike;

namespace InstaConnect.Business.Models.DTOs.Post
{
    public class PostDetailedDTO
    {
        public string Username { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<PostLikeDetailedDTO> PostLikes { get; set; }

        public ICollection<PostCommentDetailedDTO> PostComments { get; set; }
    }
}
