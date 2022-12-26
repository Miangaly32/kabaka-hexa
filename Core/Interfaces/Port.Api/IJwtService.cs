using Microsoft.AspNetCore.Identity;
using Core.DTO.Users;

namespace Core.Interfaces.Port.Api;

public interface IJwtService
{
    public AuthenticationResponse CreateToken(IdentityUser user);
}
