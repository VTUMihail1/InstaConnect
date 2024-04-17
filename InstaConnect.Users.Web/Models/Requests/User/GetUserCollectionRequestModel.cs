using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.User
{
    public class GetUserCollectionRequestModel : CollectionRequestModel
    {
        [FromQuery]
        public string UserName { get; set; }

        [FromQuery]
        public string FirstName { get; set; }

        [FromQuery]
        public string LastName { get; set; }
    }
}
