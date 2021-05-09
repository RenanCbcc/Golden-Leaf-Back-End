using Golden_Leaf_Back_End.Models.AccountModels;
using Golden_Leaf_Back_End.Models.ClerkModels;
using Golden_Leaf_Back_End.Models.ErrorModels;
using Golden_Leaf_Back_End.Settings;
using Microsoft.AspNetCore.Authentication;
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
        private readonly JWT jwt;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, JWT jwt)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwt = jwt;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            //Log out for security.
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    //var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                    var succeeded = await signInManager.UserManager.CheckPasswordAsync(user, model.Password);
                    if (succeeded)
                    {
                        return Ok(CreateAuthenticatedUser(user));
                    }

                    return Unauthorized(ErrorResponse.From($"Credenciais incorretas para o usuário com o email {model.Email}"));
                }
                return Unauthorized(ErrorResponse.From($"Nenhuma conta registrada com o email {model.Email}"));

            }

            return BadRequest(ErrorResponse.From(ModelState));
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
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

        private UserModel CreateAuthenticatedUser(ApplicationUser user)
        {
            var token = new Token
            {
                Value = CreateJwtToken(user),
                Expires = DateTime.Now.AddMinutes(jwt.DurationInMinutes)
            };

            var authenticationModel = new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = token,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Photo = user.Photo,
            };
            return authenticationModel;
        }
        private string CreateJwtToken(ApplicationUser user)
        {
            /*
             * This is the most important section of the JWT. It contains the claims, 
             * which is technically the data we are trying to secure. Claims are details 
             * about the user, expiration time of the token, etc
             */
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            };

            var key = Encoding.UTF8.GetBytes(jwt.Key);
            var symetricKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken
                (
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                expires: DateTime.Now.AddMinutes(jwt.DurationInMinutes),
                claims: claims,
                signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

    }
}

