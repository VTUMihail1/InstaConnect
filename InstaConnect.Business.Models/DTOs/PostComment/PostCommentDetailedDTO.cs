using InstaConnect.Business.Models.DTOs.CommentLike;

namespace InstaConnect.Business.Models.DTOs.PostComment
{
    public class PostCommentDetailedDTO
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Content { get; set; }

        public ICollection<PostCommentDetailedDTO> PostComments { get; set; }

        public ICollection<CommentLikeDetailedDTO> CommentLikes { get; set; }
    }
}
