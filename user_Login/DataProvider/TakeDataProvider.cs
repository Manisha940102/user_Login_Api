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
    public class TakeDataProvider : ITakeDataProvider
    {
        private readonly string connectionString = "Server=DESKTOP-S53H3V0\\MANISHASQL;Database=HR_Project;Trusted_Connection=True;";
        private SqlConnection sqlConnection;
        public IConfiguration _ConnectionString;

        public async Task<IEnumerable<Take>> getTakes()
        {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    return await sqlConnection.QueryAsync<Take>(
                        "spTakeAdd",
                        null,
                        commandType: CommandType.StoredProcedure);
                }    
        }


       public async Task<int> TakeUser(Take take)
       {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@user_id", take.user_id);
                    dynamicParameters.Add("@take_in_out", take.take_in_out);
                    dynamicParameters.Add("@serial_no", take.serial_no);
                    return await sqlConnection.QuerySingleOrDefaultAsync<int>(
                      "TakeUsers",
                     dynamicParameters,
                     commandType: CommandType.StoredProcedure);
                }   
       } 

    }
}