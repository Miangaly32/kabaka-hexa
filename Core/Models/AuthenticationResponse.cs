using System;

namespace Core.Models;

public class AuthenticationResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
