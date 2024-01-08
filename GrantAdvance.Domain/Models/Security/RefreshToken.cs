﻿namespace GrantAdvance.Domain.Models.Security
{
    public class RefreshToken : JsonWebToken
    {
        public RefreshToken(string token, long expiration) : base(token, expiration)
        { }
    }
}
