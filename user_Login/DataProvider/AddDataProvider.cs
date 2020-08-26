using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using user_Login.Models;
using user_Login.DataProvider;

namespace user_Login.DataProvider
{
    public class AddDataProvider : IAddDataProvider
    {
        private readonly string connectionString = "Server=DESKTOP-S53H3V0\\MANISHASQL;Database=HR_Project;Trusted_Connection=True;";
        private SqlConnection sqlConnection;
        public IConfiguration _ConnectionString;

        public async Task<int> AddUser(AddUser adduser)
        {
          
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@user_name", adduser.user_name);
                    dynamicParameters.Add("@password", adduser.pass);
                    dynamicParameters.Add("@email", adduser.email);
                    return await sqlConnection.QuerySingleOrDefaultAsync<int>(
                      "AdUser",
                     dynamicParameters,
                     commandType: CommandType.StoredProcedure);

                }
            
        }

        public async Task<int> updateUser(AddUser adduser)
        {

            using (sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@user_name", adduser.user_name);
                dynamicParameters.Add("@password", adduser.pass);
                dynamicParameters.Add("@email", adduser.email);
                return await sqlConnection.QuerySingleOrDefaultAsync<int>(
                  "updateUser",
                 dynamicParameters,
                 commandType: CommandType.StoredProcedure);

            }

        }


    }

   
}  