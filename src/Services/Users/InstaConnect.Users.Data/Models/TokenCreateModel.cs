using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Data.Models;
public class TokenCreateModel
{
    public ICollection<Claim> Claims { get; set; }
}
