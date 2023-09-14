﻿namespace InstaConnect.Business.Models.DTOs.Token
{
    public class TokenAddDTO
    {
        public string UserId { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
