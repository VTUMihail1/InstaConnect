using InstaConnect.Shared.Business.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Shared.Business.Exceptions.Follow
{
    public class FollowNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE = "Post comment not found";

        public FollowNotFoundException() : base(ERROR_MESSAGE)
        {
        }

        public FollowNotFoundException(Exception exception) : base(ERROR_MESSAGE, exception)
        {
        }
    }
}
