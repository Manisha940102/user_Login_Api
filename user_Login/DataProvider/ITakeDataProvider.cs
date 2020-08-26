using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_Login.Models;

namespace user_Login.DataProvider
{
   public interface ITakeDataProvider
    {
        Task<IEnumerable<Take>> getTakes();
        Task<int> TakeUser(Take take);
    }

}
