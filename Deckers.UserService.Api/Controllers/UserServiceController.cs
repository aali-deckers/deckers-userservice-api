using Deckers.UserService.Application.Serviecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Identity;



namespace Deckers.UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServiceController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly SignInManager<CognitoUser> _signInManager;
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;


        public UserServiceController(IUserService userService, SignInManager<CognitoUser> signInManager, UserManager<CognitoUser> userManager, CognitoUserPool pool)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _signInManager = signInManager;
            _userManager = userManager;
            _pool = pool;
        }

        [HttpGet]
        [Route("authenticateUser/{userName}/{password}")]
        public async Task<IActionResult> GetUserDetailsAsync(string userName, string password)
        {
            var user = await _signInManager.PasswordSignInAsync(userName, password, false, true);
            //var user1 = _signInManager.pa
            
            var result = _userService.GetUserDetails(userName, password);

            if (result != null && result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}

