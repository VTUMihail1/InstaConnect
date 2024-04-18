using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.User
{
    public class GetUserCollectionRequestModel : CollectionRequestModel
    {
        [FromQuery(Name = "userName")]
        public string UserName { get; set; } = string.Empty;

        [FromQuery(Name = "firstName")]
        public string FirstName { get; set; } = string.Empty;

        [FromQuery(Name = "lastName")]
        public string LastName { get; set; } = string.Empty;
    }
}
