using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_Login.Models;

namespace user_Login.DataProvider
{
     public interface IAddDataProvider
    {
        Task<int> AddUser(AddUser adduser);
        Task<int> updateUser(AddUser adduser);
    }
}
