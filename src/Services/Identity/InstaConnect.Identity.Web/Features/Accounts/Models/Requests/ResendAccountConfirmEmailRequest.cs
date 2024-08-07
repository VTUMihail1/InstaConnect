﻿using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Accounts.Models.Requests;

public class ResendAccountConfirmEmailRequest
{
    [FromRoute]
    public string Email { get; set; } = string.Empty;
}