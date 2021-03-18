using Golden_Leaf_Back_End.Models.ClerkModels;
using Golden_Leaf_Back_End.Models.ErrorModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class ClerkController : ControllerBase
    {
        private readonly UserManager<Clerk> userManager;
        private readonly SignInManager<Clerk> signInManager;
        private readonly IConfiguration configuration;

        public ClerkController(UserManager<Clerk> userManager,
            SignInManager<Clerk> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
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
                        var clerk = new
                        {
                            Token = GenerateJwt(model.Email),
                            Name = user.UserName,
                            Photo = user.Photo,
                            Id = user.Id
                        };

                        return Ok(clerk);
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
                var clerk = new Clerk() { UserName = model.Name, Email = model.Email };
                var result = await userManager.CreateAsync(clerk, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(clerk, isPersistent: false);
                    return Ok("Usuário criado! Faça o login.");
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
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,DateTime.Now.AddHours(1).ToString())
            };

            var key = Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]);
            var symetricKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken
                (
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(1),
                claims: rights,
                signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

    }
}

