using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Models;
public record AddFollowClientRequest(
    AddFollowRequest AddFollowRequest, 
    bool IsAuthenticated = true);
