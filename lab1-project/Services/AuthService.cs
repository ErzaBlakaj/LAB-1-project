using Dapper;
using System.Data.SqlClient;
using System.Data;
using lab1_project.Models;

namespace lab1_project.Services
{
    public class AuthService
    {
        private string _connectionString { get; set; }

        public AuthService(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int RegisterNewUser(string emri, string mbiemri, string email, string fjalekalimi, int? id_role)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Emri", emri);
                parameters.Add("@Mbiemri", mbiemri);
                parameters.Add("@Email", email);
                parameters.Add("@Fjalekalimi", fjalekalimi);
                parameters.Add("@Id_role", id_role);

                int newUserId = connection.QuerySingleOrDefault<int>(
                    "RegisterNewUser",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return newUserId;
            }
        }


        public LoginResponse LoginUser(string email, string fjalekalimi)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Email", email);
                parameters.Add("@Fjalekalimi", fjalekalimi);


                return connection.QuerySingleOrDefault<LoginResponse>(
                    "LoginUser",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


    }
}
