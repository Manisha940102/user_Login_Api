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

namespace User_Login.DataProvider
{
    public class LoginDataProvider : ILoginDataProvider
    {
        private readonly string connectionString = "Server=DESKTOP-S53H3V0\\MANISHASQL;Database=HR_Project;Trusted_Connection=True;";
        private SqlConnection sqlConnection;
        public IConfiguration _ConnectionString;

        public async Task<IEnumerable<Login>> getLogins()
        {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    return await sqlConnection.QueryAsync<Login>(
                        "spLoginAdd",
                        null,
                        commandType: CommandType.StoredProcedure);
                }
        }
        public async Task<int> LoginUser(Login login)
        {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@user_name", login.user_name);
                    dynamicParameters.Add("@password", login.pass);
                    return await sqlConnection.QuerySingleOrDefaultAsync<int>(
                      "LoginUser",
                     dynamicParameters,
                     commandType: CommandType.StoredProcedure);

                }
        }

        public async Task<UserResponse> GetUser(User user)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@user_name", user.user_name);
                    dynamicParameters.Add("@password", user.pass);
                    return await sqlConnection.QuerySingleOrDefaultAsync<UserResponse>(
                      "getUsr",
                     dynamicParameters,
                     commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
          

        }

    }
}