using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using user_Login.DataProvider;
using user_Login.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace user_Login.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private ILoginDataProvider loginDataProvider;

        public LoginController(ILoginDataProvider loginDataProvider)
        {
            this.loginDataProvider = loginDataProvider;
        }

     /*   [HttpGet]
        public async Task<IEnumerable<Login>> Get()
        {
            return await this.loginDataProvider.getLogins();
        }
        */
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login login, LoginResponse loginResponse)
        {
            var a = await this.loginDataProvider.LoginUser(login);

            if (a == 0)
            {
                loginResponse.message = "LoginUnsuccessful";
                loginResponse.status = -1;
            }
            else
            {
                loginResponse.message = "LoginSuccessful";
                loginResponse.status = 1;
                loginResponse.user_id = a;
            }
            return Ok(loginResponse);
        }

        [HttpGet]
        public async Task<UserResponse> Get([FromBody] User user)
        {
            UserResponse userResponse = await this.loginDataProvider.GetUser(user);
            return (userResponse);

        }

    }
}

      
