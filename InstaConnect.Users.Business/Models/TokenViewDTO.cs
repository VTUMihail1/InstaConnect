using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Business.Models
{
    public class TokenViewModel
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
