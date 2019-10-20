using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Blog.Data.Models;
using Blog.Infrastructure.Data.Models;
using Blog.Services.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Blog.Services.Core.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger,
            UrlEncoder encoder, 
            ISystemClock clock,
            IUserService userService) : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");
            User user;
            try
            {
                var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credBytes = Convert.FromBase64String(header.Parameter);
                var credentials = Encoding.UTF8.GetString(credBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];
                user = await Task.Run(() => _userService.AuthenticateUser(username, password)); 
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null)
                return AuthenticateResult.Fail("Invalid Username or Password");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            try
            {
                var roles = _userService.GetUserRoles(user.UserName).ToArray();
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Process");
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{Request.Scheme}//{Request.Host}\", charset=\"UTF-8\"";
            await base.HandleChallengeAsync(properties);
        }
    }
}