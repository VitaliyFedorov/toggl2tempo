using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebHost.ClientApi.Synchronization
{
    public class AuthenticationController : Controller
    {
        private readonly IApplicationUserService _userService;
        private IConfiguration _configuration;

        public AuthenticationController(IApplicationUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Authorize]
        [Route("api/[controller]/[action]")]
        public void SignInJira([FromBody] JiraAuthModel model)
        {
        }

        [HttpPost]
        [Authorize]
        [Route("api/[controller]/[action]")]
        public void SignInToggl([FromBody] TogglAuthModel model)
        {
            _userService.SaveTogglTokenForCurrentUser(model.Token);
        }

        [HttpPost]
        [Authorize]
        [Route("api/[controller]/[action]")]
        public void SignInTempo([FromBody] TempoAuthModel model)
        {
            _userService.SaveTempoTokenForCurrentUser(model.Token);
        }
    }
}