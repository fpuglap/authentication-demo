using System;

namespace AuthenticationDemo;

public class JwtBearerSettings
{
    public string Issuer { get; set; }

    public string Audience { get; set; }

    public string SigninKey { get; set; }
}