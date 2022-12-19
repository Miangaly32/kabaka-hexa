using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core.Interfaces.Port.Api;

namespace Adapter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJwtService _jwtService;

    public UsersController(UserManager<IdentityUser> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userManager.CreateAsync(
            new IdentityUser() { UserName = user.UserName, Email = user.Email },
            user.Password
        );

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        user.Password = null;
        return Created("", user);
    }

    [HttpPost("BearerToken")]
    public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Bad credentials");
        }

        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user == null)
        {
            return BadRequest("Bad credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }

        var token = _jwtService.CreateToken(user);

        return Ok(token);
    }
}