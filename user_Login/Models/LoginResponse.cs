using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user_Login.Models
{
    public class LoginResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public int user_id { get; set; }
    }
}
