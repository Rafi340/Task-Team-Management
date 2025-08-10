using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using TTMS.Domain.Contract.Request;
using TTMS.Infrastructure.Identity;

namespace TTMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(ILogger<AccountController> logger,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IConfiguration _configuration,
        ITokenService tokenService
        ) : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IConfiguration _configuration = _configuration;

        [AllowAnonymous]
        [HttpPost(ApiEndpoints.Auth.login)]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request.Email != null && request.Password != null)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

                if (result != null && result.Succeeded)
                {
                    var claims = (await _userManager.GetClaimsAsync(user)).ToArray();
                    var token = await _tokenService.GetJwtToken(claims,
                            _configuration["Jwt:Key"],
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"]
                        );

                    return Ok(token);
                }
                else
                {
                    return Unauthorized(new { message = "Invalid credentials" });
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
