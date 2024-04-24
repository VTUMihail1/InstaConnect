using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Posts.Business.Models
{
    public class PostCommentLikeViewDTO
    {
        public string Id { get; set; }

        public string PostCommentId { get; set; }

        public string UserId { get; set; }
    }
}
