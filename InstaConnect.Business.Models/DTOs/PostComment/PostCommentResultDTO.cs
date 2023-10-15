using InstaConnect.Business.Models.DTOs.PostCommentLike;

namespace InstaConnect.Business.Models.DTOs.PostComment
{
    public class PostCommentResultDTO
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Content { get; set; }

        public ICollection<PostCommentResultDTO> PostComments { get; set; }

        public ICollection<PostCommentLikeResultDTO> CommentLikes { get; set; }
    }
}
