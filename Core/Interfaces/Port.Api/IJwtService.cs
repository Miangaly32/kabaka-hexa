using Microsoft.AspNetCore.Identity;
using Core.Models;

namespace Core.Interfaces.Port.Api;

public interface IJwtService
{
    public AuthenticationResponse CreateToken(IdentityUser user);
}
