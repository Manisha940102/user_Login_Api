using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_Login.Models;

namespace user_Login.DataProvider
{
    public interface ILoginDataProvider
    {
        Task<IEnumerable<Login>> getLogins();
        Task <int>LoginUser(Login login);
        Task<UserResponse> GetUser(User user);
    }

}
