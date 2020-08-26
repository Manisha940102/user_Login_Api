using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using user_Login.DataProvider;
using user_Login.Models;


namespace user_Login.Controllers
{
    [Route("api/user")]
    public class AddController : Controller
    {
        private IAddDataProvider addDataProvider;

        public AddController(IAddDataProvider addDataProvider)
        {
            this.addDataProvider = addDataProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUser adduser, AddResponse addResponse)
        {
            var a = await this.addDataProvider.AddUser(adduser);

            if (a == 1)
            {
                addResponse.message = "UserSuccessfullyAdded";
                addResponse.status = 1;
            }
            else
            {
                addResponse.message = "UserAddingFailed";
                addResponse.status = -1;
            }
            return Ok(addResponse);
        }

    }
}


