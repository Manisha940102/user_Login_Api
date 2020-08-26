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
    [Route("api/take")]
    public class TakeController : Controller
    {
        private ITakeDataProvider takeDataProvider;
        public TakeController(ITakeDataProvider takeDataProvider)
        {
            this.takeDataProvider = takeDataProvider;
        }

        [HttpGet("gettakes")]
        public async Task<IEnumerable<Take>> Get()
        {  
            return await this.takeDataProvider.getTakes();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Take take, TakeResponse takeResponse)
        {
              
            var a = await this.takeDataProvider.TakeUser(take);
          
            if (a == 1)
            {
                takeResponse.message = "RecordSuccessfullyEntered";
                takeResponse.status = 1;
            }
            else
            {
                takeResponse.message = "RecordEnteringUnsuccessful";
                takeResponse.status = 0;
            }
            return Ok(takeResponse);            
        }          
    }
}


