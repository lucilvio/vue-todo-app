using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Vue.TodoApp
{
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly TodoAppContext _context;
        private readonly JwtTokenGenerator _tokenGenerator;
        private readonly AppSettings _appSettings;

        public TokenController(TodoAppContext context, JwtTokenGenerator tokenGenerator, IOptions<AppSettings> appSettings)
        {
            this._context = context ?? throw new System.ArgumentNullException(nameof(context));
            this._tokenGenerator = tokenGenerator ?? throw new System.ArgumentNullException(nameof(tokenGenerator));
            this._appSettings = appSettings != null ? appSettings.Value : throw new System.ArgumentNullException(nameof(appSettings));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]TokenPostRequest request)
        {
            var issuer = base.Request.Headers["iss"];
            var audience = base.Request.Headers["aud"];

            var foundUser = await this._context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == request.User && u.Password == request.Password);

            if(foundUser is null)
                return BadRequest(new { message = "Invalid user os password" });

            try
            {
                var token = _tokenGenerator.Generate(foundUser, issuer, audience);

                return Ok(new
                {
                    name = foundUser.Name,
                    email = foundUser.Email,
                    token
                });
            }
            catch (TokenGenerationException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        public record TokenPostRequest(string User, string Password);
    }
}