using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllPostComments
{
    public class GetAllPostCommentsQuery : CollectionDTO, IQuery<ICollection<PostCommentViewDTO>>
    {
    }
}
