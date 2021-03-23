using Golden_Leaf_Back_End.Models;
using Golden_Leaf_Back_End.Models.ClerkModels;
using Golden_Leaf_Back_End.Models.ErrorModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly Variables variables;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
                    Variables variables)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.variables = variables;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    //var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                    var succeeded = await signInManager.UserManager.CheckPasswordAsync(user, model.Password);
                    if (succeeded)
                    {

                        return Ok(
                            new
                            {
                                user.Id,
                                user.UserName,
                                Token = GenerateJwt(model.Email),
                                user.PhoneNumber,
                                user.Email,
                                user.Photo,
                            }
                        );
                    }

                    return Unauthorized(ErrorResponse.From("Login ou senha incorretos."));
                }
                return Unauthorized(ErrorResponse.From("Login ou senha incorretos."));

            }

            return BadRequest(ErrorResponse.From(ModelState));
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.Name, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(new { user.Id, user.UserName, user.PhoneNumber, user.Photo });
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(ModelState);
        }

        private string GenerateJwt(string email)
        {
            //token(header + payload ->(rights) + signature)
            var rights = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var key = Encoding.UTF8.GetBytes(variables.Key);
            var symetricKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken
                (
                issuer: variables.Issuer,
                audience: variables.Audience,
                expires: DateTime.Now.AddHours(2),
                claims: rights,
                signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

    }
}

